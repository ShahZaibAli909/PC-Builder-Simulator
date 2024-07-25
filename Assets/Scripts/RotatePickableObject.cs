using UnityEngine;

public class RotatePickableObject : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) // Button for X-axis rotation
        {
            RotateObject(90, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Y)) // Button for Y-axis rotation
        {
            RotateObject(0, 90, 0);
        }
        if (Input.GetKeyDown(KeyCode.Z)) // Button for Z-axis rotation
        {
            RotateObject(0, 0, 90);
        }
    }

    private void RotateObject(float xAngle, float yAngle, float zAngle)
    {
        transform.Rotate(new Vector3(xAngle, yAngle, zAngle));
    }
}
