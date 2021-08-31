using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 playerMouseInput;
    private Vector3 playerMovementInput;
    private float xRot;
    private bool grounded;
    private Rigidbody playerBody;
    [SerializeField] private Transform playerCam;
    [SerializeField] private float speed;
    [SerializeField] private float jumpforce;
    [SerializeField] private float sensitivity;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundRayDistance;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = GetComponent<Rigidbody>();
        if (playerBody == null)
        {
            Debug.LogError("Rigidbody not could not be assigned on Player");
        }

    }
    private void Update()
    {
        playerMovementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        playerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        CheckGrounded();
        MovePlayer();
        MoveCamera();
    }
    private void MovePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(playerMovementInput) * speed;
        playerBody.velocity = new Vector3(moveVector.x, playerBody.velocity.y, moveVector.z);
        PlayerInput();
    }
    private void MoveCamera()
    {
        xRot -= playerMouseInput.y * sensitivity;
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        transform.Rotate(0f, playerMouseInput.x * sensitivity, 0f);
        playerCam.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }
    private void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    private void Jump()
    {
        if (grounded)
            playerBody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
    }
    private void CheckGrounded()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, groundRayDistance, groundMask))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 dir = Vector2.down * groundRayDistance;
        Gizmos.DrawRay(transform.position, dir);
    }
}
