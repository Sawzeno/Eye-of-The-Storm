using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class Hero : MonoBehaviour
{
    public float speed = 0.5f;

    [SerializeField] private float driftSpeed = 0.1f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float jumpForce;
    [SerializeField] private float angularClamp = 30f;
    [SerializeField] private float fallSpeed = -10f;
    

    private Transform model;
    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;
    private Rigidbody character;
  
    private float mX = 0.0f;
    private float mY = 0.0f;
    
    private void Awake()
    {
        velocity = Vector3.forward * driftSpeed;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
        model = transform.GetChild(0);
    }
    
    private void Update()
    {
        ControlPlayer();
        Jump();
        RotateBody();
    }
    
    private void FixedUpdate()
    {
        ManualGravity();
    }

    private void ManualGravity()
    {
        if (characterController.isGrounded) return;
        velocity.y = fallSpeed;
    }

    private void ControlPlayer()
    {
        float xAxisValue = Input.GetAxis("Horizontal");
        float zAxisValue = Input.GetAxis("Vertical");
        Vector3 moveDirection = new(xAxisValue, 0, zAxisValue);
        characterController.Move( velocity + moveDirection * (speed * 0.1f));
    }

    private void Jump()
    {
        if (!characterController.isGrounded || !Input.GetButtonDown("Jump")) return;
        velocity.y = Mathf.Sqrt(jumpHeight);
    }

    private void RotateBody()
    {
        mX += Input.GetAxis("Mouse Y");
        mY += Input.GetAxis("Mouse X");
        if (mX > angularClamp) mX = angularClamp;
        if (mY > angularClamp) mY = angularClamp;
        if (mX < -angularClamp) mX = -angularClamp;
        if (mY < -angularClamp) mY = -angularClamp;
        model.eulerAngles = new Vector3(mX, mY, 0);
    }
}


//----------------------------------------------------------comments

// if (Input.GetKeyDown(KeyCode.W))
// {
//     velocity.z += forwardInput;
//     velocity.x = 0;
//     // Debug.Log("W");
// }

// if (Input.GetKeyDown(KeyCode.S))
// {
//     velocity.z -= backInput;
//     // Debug.Log("S");
// }
//
// if (Input.GetKeyDown(KeyCode.A))
// {
//     if (velocity.x > 0)
//     {
//         velocity.x = 0;
//     }
//     velocity.x -= leftAndRight;
//     // Debug.Log("A");
// }
//
// if (Input.GetKeyDown(KeyCode.D))
// {
//     if (velocity.x < 0)
//     {
//         velocity.x = 0;
//     }
//     velocity.x += leftAndRight;
//     // Debug.Log("D");
// }


// private void Start()
// {
//     character = GetComponent<Rigidbody>();
//     characterController = GetComponent<CharacterController>();
// }
//
// private void Update()
// {
//     transform.position = new Vector3(HorizontalInput, 0, Mathf.Abs(HorizontalInput) - 1);
//     characterController.Move(new Vector3(0, 0, HorizontalInput * runSpeed) * Time.deltaTime +
//                              velocity * Time.deltaTime);
// }
//
// private void FixedUpdate()
// {
//     if (characterController.isGrounded)
//     {
//         transform.position.y -= 10f;
//     }
// }


//---------------------------------------------------------------fuck this