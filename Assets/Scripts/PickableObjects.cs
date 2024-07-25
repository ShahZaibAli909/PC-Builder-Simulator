using UnityEngine;
using System.Collections;

public class PickableObjects : MonoBehaviour
{
    private static PickableObjects _currentPickedObject;
    private Transform _grabableObjectTransform;
    private Rigidbody _rigidbody;
    private Renderer _objectRenderer;
    [SerializeField] public GameObject _placeToSetPickedObject;
    [SerializeField] private float _grabPointY;
    [SerializeField] private float _grabPointX;
    [SerializeField] private float _grabPointZ;
    private GameManger gameManager;
    public bool _isGrabed { get; private set; } = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManger>();
        _objectRenderer = GetComponent<Renderer>();

        if (_placeToSetPickedObject != null)
        {
            _placeToSetPickedObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Place to set picked object is not assigned.");
        }
    }

    public void Grab(Transform grabableObjectTransform)
    {
        gameManager.displayText.text = "Attempting to grab object: " + gameObject.name;

        if (grabableObjectTransform == null)
        {
            Debug.LogError("GrabableObjectTransform is null.");
            return;
        }

        if (_currentPickedObject == null)
        {
            _currentPickedObject = this;
            grabableObjectTransform.localPosition = new Vector3(_grabPointX, _grabPointY, _grabPointZ);
            this._grabableObjectTransform = grabableObjectTransform;
            _rigidbody.useGravity = false;
            _isGrabed = true;
            if (_placeToSetPickedObject != null)
            {
                _placeToSetPickedObject.SetActive(true);
            }
          
            gameManager.displayText.text = "Object grabbed: " + gameObject.name;
        }
        else
        {
           
            gameManager.displayText.text = "Another object is already picked: " + _currentPickedObject.name;
        }
    }


    public void ReleaseObject()
    {
        _currentPickedObject = null;
        this._grabableObjectTransform = null;
        _rigidbody.useGravity = true;
        _isGrabed = false;
        StartCoroutine(DeactivateAfterDelay());
    }

    private IEnumerator DeactivateAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        if (_placeToSetPickedObject != null)
        {
            _placeToSetPickedObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (_grabableObjectTransform != null)
        {
            float lerpSpeed = 8f;
            Vector3 newPosition = Vector3.Lerp(transform.position, _grabableObjectTransform.position, Time.deltaTime * lerpSpeed);
            _rigidbody.MovePosition(newPosition);
        }
    }
}
