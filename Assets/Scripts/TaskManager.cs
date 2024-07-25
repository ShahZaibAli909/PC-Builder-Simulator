using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TaskManager : MonoBehaviour
{
    private GameManger gameManager;

    // Displaying the task in UI
    [SerializeField] private TextMeshProUGUI tasksShow;

    // Custom Task class to store task status
    [System.Serializable]
    public class Task
    {
        public string TaskName;  // Task identifier
        public bool IsCompleted; // Task completion status

        public Task(string taskName)
        {
            TaskName = taskName;
            IsCompleted = false;
        }
    }

    [SerializeField] private List<Task> tasks = new List<Task>();

    [SerializeField] int noOfTaskThisLevel;
    public int completedTask = 0;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManger>();
        noOfTaskThisLevel = tasks.Count;

        ShowTasks(); // Display tasks at the start
    }

    // Method to update the task status
    public void UpdateTaskStatus(string taskName, bool isCompleted)
    {
        foreach (var task in tasks)
        {
            if (task.TaskName == taskName)
            {
                if (task.IsCompleted != isCompleted)
                {
                    gameManager.displayText.text = taskName + " completed!";
                    task.IsCompleted = isCompleted;
                    completedTask += isCompleted ? 1 : -1;
                    ShowTasks();
                    CheckLevelCompletion();
                }
                break;
            }
        }
    }

    public void ShowTasks()
    {
        tasksShow.text = " ";
        foreach (var task in tasks)
        {
            tasksShow.text += task.TaskName + ":                       " + (task.IsCompleted ? "Completed" : "Incomplete") + "\n";
        }
    }

    // Method to check if all tasks are completed
    private void CheckLevelCompletion()
    {
        if (noOfTaskThisLevel == completedTask)
        {
            StartCoroutine(LevelEnd());
            gameManager.displayText.text = "Level Completed:";
            StartCoroutine(loadNextLevel());
        }
    }

    IEnumerator loadNextLevel()
    {
        yield return new WaitForSeconds(3f);
        Scene currentScene = SceneManager.GetActiveScene();
        // Get the build index of the current scene
        int buildIndex = currentScene.buildIndex + 1;
        SceneManager.LoadScene(buildIndex);
    }

    IEnumerator LevelEnd()
    {
        yield return new WaitForSeconds(3f);
    }
}
