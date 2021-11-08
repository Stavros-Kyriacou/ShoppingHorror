using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12;
    private CharacterController controller;
    public float gravity = -9.81f;
    public float weight;
    Vector3 velocity;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundRayDistance;
    private bool isGrounded;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        isGrounded = CheckGrounded();

        //stop velocity from gravity building up when grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //movement
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        move.Normalize();

        controller.Move(move * speed * Time.deltaTime);

        //gravity
        velocity.y += gravity * ( weight * 0.01f) * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private bool CheckGrounded()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, groundRayDistance, groundMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //human height      1.75m        unity height    4.0m
    //ceiling height    3.6m minimum        unity height    8.2m
    // *2.28


    // private Vector2 playerMouseInput;
    // private Vector3 playerMovementInput;
    // private float xRot;
    // private Rigidbody playerBody;
    // [SerializeField] private Transform playerCam;
    // [SerializeField] private float speed;
    // [SerializeField] private float jumpforce;
    // [SerializeField] private float sensitivity;
    // [SerializeField] private LayerMask groundMask;
    // [SerializeField] private float groundRayDistance;
    // private bool isGrounded;


    // private void Start()
    // {
    //     Cursor.lockState = CursorLockMode.Locked;
    //     playerBody = GetComponent<Rigidbody>();
    //     if (playerBody == null)
    //     {
    //         Debug.LogError("Rigidbody not could not be assigned on Player");
    //     }

    // }
    // private void Update()
    // {
    //     playerMovementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
    //     playerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    //     CheckGrounded();
    //     PlayerInput();
    //     MoveCamera();
    // }
    // private void FixedUpdate() {
    //     MovePlayer();
    // }
    // private void MovePlayer()
    // {
    //     Vector3 moveVector = transform.TransformDirection(playerMovementInput) * speed;
    //     playerBody.velocity = new Vector3(moveVector.x, playerBody.velocity.y, moveVector.z);
    // }
    // private void MoveCamera()
    // {
    //     xRot -= playerMouseInput.y * sensitivity;
    //     xRot = Mathf.Clamp(xRot, -90f, 90f);
    //     transform.Rotate(0f, playerMouseInput.x * sensitivity, 0f);
    //     playerCam.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    // }
    // private void PlayerInput()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         Jump();
    //     }
    // }
    // private void Jump()
    // {
    //     if (isGrounded)
    //         playerBody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
    // }
    // private void CheckGrounded()
    // {
    //     Ray ray = new Ray(transform.position, Vector3.down);
    //     RaycastHit hit;

    //     if (Physics.Raycast(ray, out hit, groundRayDistance, groundMask))
    //     {
    //         isGrounded = true;
    //     }
    //     else
    //     {
    //         isGrounded = false;
    //     }
    // }
    // private void OnDrawGizmosSelected()
    // {
    //     Gizmos.color = Color.red;
    //     Vector3 dir = Vector2.down * groundRayDistance;
    //     Gizmos.DrawRay(transform.position, dir);
    // }
}
