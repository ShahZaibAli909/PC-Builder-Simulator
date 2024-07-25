using UnityEngine;
using UnityEngine.UI;

public class LightsOnOff : MonoBehaviour
{
    [SerializeField] private Light _lightLeft;
    [SerializeField] private Light _lightRight;
    [SerializeField] private string taskName; // Name of the task to be updated
    private bool _isInRange = false;
    private bool _islightOn = false;

    [SerializeField] private GameObject _buttonActive;
    private TaskManager taskManager;
    private GameManger gameManger;

    void Start()
    {
        if (_lightLeft == null || _lightRight == null)
        {
            Debug.LogError("Lights are not assigned in the inspector.");
            return;
        }

        _lightLeft.enabled = false;
        _lightRight.enabled = false;

        taskManager = FindObjectOfType<TaskManager>();
        gameManger = FindObjectOfType<GameManger>();

        if (taskManager == null)
        {
            Debug.LogError("TaskManager not found in the scene.");
        }

        if (gameManger == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }

        if (_buttonActive != null)
        {
            _buttonActive.SetActive(false);
        }
        else
        {
            Debug.LogError("ButtonActive is not assigned in the inspector.");
        }
    }

    public void LightOn()
    {
        if (!_islightOn && _isInRange)
        {
           
            _lightLeft.enabled = true;
            _lightRight.enabled = true;
            _islightOn = true;
            taskManager.UpdateTaskStatus(taskName, true);
        }
        else if (_islightOn && _isInRange)
        {
            _lightLeft.enabled = false;
            _lightRight.enabled = false;
            _islightOn = false;
            taskManager.UpdateTaskStatus(taskName, false);
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            _isInRange = true;
            _buttonActive.SetActive(true);
            gameManger.displayText.text = "Switch Light On";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            _isInRange = false;
            _buttonActive.SetActive(false);
            gameManger.displayText.text = "";
        }
    }
}
