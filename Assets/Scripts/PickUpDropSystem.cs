using UnityEngine;

public class PickUpDropSystem : MonoBehaviour
{
    [SerializeField] Transform PlayerCameraPosition;
    [SerializeField] LayerMask _playerLayerMask; // to classify objects that are to be selected
    [SerializeField] private Transform _grabObjectPointTransform;
    private PickableObjects pickAbleObject;
    private PickableObjects highlightedObject;
    [SerializeField] int _maxDistance;
   
    public void GrabAndReleaseObject()
    {
        HandleHighlighting();

        if (pickAbleObject == null && highlightedObject != null)//grabing the object
        {
            pickAbleObject = highlightedObject;
            if (!pickAbleObject._isGrabed)
            {
                pickAbleObject.Grab(_grabObjectPointTransform);
                highlightedObject = null;
            }
        }
        else if (pickAbleObject != null)//releasing the obkect
        {
            if (pickAbleObject._isGrabed)
            {
                pickAbleObject.ReleaseObject();
                pickAbleObject = null;
            }
        }
    }

    private void HandleHighlighting()
    {
        highlightedObject = null;
        Debug.DrawRay(PlayerCameraPosition.position, PlayerCameraPosition.forward * _maxDistance, Color.red);

        if (Physics.Raycast(PlayerCameraPosition.position, PlayerCameraPosition.forward, out RaycastHit raycastHit, _maxDistance, _playerLayerMask))
        {

            if (raycastHit.transform.TryGetComponent(out PickableObjects pickable))
            {
                highlightedObject = pickable;
               
            }
        }
    }

}
