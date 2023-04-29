﻿using System;
using UnityEngine;

public class CameraOrbitView : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    Vector3 localRotation;

    public void SetFocalPoint (Transform point) => transform.position = point.position;

    void Start ()
    {
        localRotation = transform.rotation.eulerAngles;
    }

    void RotateCamera ()
    {
        float xAxis = Input.GetAxis("Mouse X");
        float yAxis = Input.GetAxis("Mouse Y");
        float xInput = xAxis * rotationSpeed * Time.deltaTime;
        float yInput = yAxis * rotationSpeed * Time.deltaTime;
        localRotation.x += xInput;
        localRotation.y -= yInput;
        localRotation.y = Mathf.Clamp(localRotation.y, 5f, 85f);

        transform.rotation = Quaternion.Euler(localRotation.y, localRotation.x, 0f);
    }

    void Update ()
    {
        if (Input.GetMouseButton(0))
            RotateCamera();
    }
}