using Microsoft.Win32.SafeHandles;
using UnityEngine;

public class PlaceThePickedObject : MonoBehaviour
{

    [SerializeField] private GameObject pickedObject;
    [SerializeField] private string taskName; // Name of the task to be updated
    private TaskManager taskManager;

    private void Start()
    {
        // Find the TaskManager in the scene
        taskManager = FindObjectOfType<TaskManager>();
        if (taskManager == null)
        {
            Debug.LogError("TaskManager not found in the scene!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "pickableObject")
        {
            
            pickedObject.transform.rotation = transform.rotation;
            taskManager.UpdateTaskStatus(taskName, true);
           
            // pickedObject.transform.position = transform.position;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "pickableObject")
        {
            taskManager.UpdateTaskStatus(taskName, false);
           // Debug.Log("not here");
        }
    }
}
