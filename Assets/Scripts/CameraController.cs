using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector2 playerMouseInput;
    private float xRot;

    [SerializeField] private Transform playerCam;
    [Space]
    [SerializeField] private float sensitivity;

    private void Update() {
        playerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        MoveCamera();
    }
    private void MoveCamera()
    {
        xRot -= playerMouseInput.y * sensitivity;
        transform.Rotate(0f, playerMouseInput.x * sensitivity, 0f);
        playerCam.transform.rotation = Quaternion.Euler(xRot, 0f, 0f);
    }


    // [SerializeField] private float mouseSensitivity = 100f;
    // [SerializeField] private Transform playerBody;
    // private float mouseX, mouseY;
    // private float xRotation = 0f;
    // void Start()
    // {
    //     
    // }
    // void Update()
    // {
    //     MouseMovement();
    // }
    // private void MouseMovement()
    // {
    //     mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
    //     mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    //     xRotation -= mouseY;
    //     

    //     transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    //     playerBody.Rotate(Vector3.up * mouseX);
    // }
}
