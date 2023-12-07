using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float mouseSensitivity;
    public Transform playerBody;
    public Transform orientation;
    float xRotation = 0f;
    void Start()
    {
        /*Cursor.lockState = CursorLockMode.Locked;*/
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        float playerRotationY = playerBody.eulerAngles.y;
        orientation.eulerAngles = new Vector3(0, playerRotationY, 0);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}