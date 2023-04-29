using UnityEngine;

public class CameraOrbitController : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    Vector3 localRotation = Vector3.zero;

    void Update ()
    {
        if (Input.GetMouseButton(0))
            RotateCamera();
    }

    void SetFocalPoint (Transform point) => transform.position = point.position;

    void RotateCamera ()
    {
        float xAxis = Input.GetAxis("Mouse X");
        float yAxis = Input.GetAxis("Mouse Y");
        float xInput = xAxis * rotationSpeed * Time.deltaTime;
        float yInput = yAxis * rotationSpeed * Time.deltaTime;
        localRotation.x += xInput;
        localRotation.y -= yInput;
        localRotation.y = Mathf.Clamp(localRotation.y, 0f, 85f);

        transform.rotation = Quaternion.Euler(localRotation.y, localRotation.x, 0f);
    }
}