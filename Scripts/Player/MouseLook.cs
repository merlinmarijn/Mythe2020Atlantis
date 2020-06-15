using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mousSensitivity;

    public Transform playerBody;

    float xRotation = 0f;
    public bool canRotate = true;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mousSensitivity = GlobalSettings.Sensitivity;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else { Cursor.lockState = CursorLockMode.Locked; Cursor.visible = false; }
        }
        if (canRotate)
        {
        float mouseX = Input.GetAxis("Mouse X") * mousSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mousSensitivity * Time.deltaTime;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            playerBody.Rotate(Vector3.up * mouseX);
        }

    }
}
