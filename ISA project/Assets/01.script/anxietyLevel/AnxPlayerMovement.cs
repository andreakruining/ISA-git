using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxPlayerMovement : MonoBehaviour
{
    //movement
    [Header("Movement")]
    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float groundDrag = 3f;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizantalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    //public float turnSmoothTime = 0.1f;
    //float turnSmoothVelocity;

    //[SerializeField]
    //private Transform cameraTransform;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        //perform ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        SpeedControl();
        //MyInput();
        Move();

        //handle drag
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {

    }

    private void Move()
    {
        horizantalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        moveDirection = orientation.forward * verticalInput + orientation.right * horizantalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 4f, ForceMode.Force);

        // moveDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * moveDirection;
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit veolicity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}