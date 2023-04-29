using UnityEngine;

public class CameraOrbitController : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    void Update ()
    {
        if (Input.GetMouseButton(0))
            RotateCamera();
    }

    void RotateCamera ()
    {
        float xAxis = Input.GetAxis("Mouse X");
        float yAxis = Input.GetAxis("Mouse Y");
        
        if (xAxis != 0 || yAxis != 0)
        {
            float xInput = xAxis * rotationSpeed * Time.deltaTime;
            float yInput = yAxis * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, xInput, Space.World);
            transform.Rotate(-Vector3.right, yInput);
        }
    }
}