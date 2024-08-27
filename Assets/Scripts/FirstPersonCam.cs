using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCam : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform playerBody;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        //[SerializeField] private Player player;
        //public float turnSpeed = 4.0f;
        //public float minTurnAngle = -90.0f;
        //public float maxTurnAngle = 90.0f;
        //private float rotX;

        //private void Start()
        //{
        //    player = FindObjectOfType<Player>();
        //}
        //public void MouseAiming()
        //{
        //    // get the mouse inputs
        //    float y = Input.GetAxis("Mouse X") * turnSpeed;
        //    rotX += Input.GetAxis("Mouse Y") * turnSpeed;
        //    // clamp the vertical rotation
        //    rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);
        //    // rotate the camera
        //    transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
        //}
    }
}
