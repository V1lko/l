using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    //VARIABLES
    [Header("VARIABLES Speed:")]
    [SerializeField] [Range(5,20)] float runSpeed;
    [SerializeField] [Range(5, 20)] float jumpForce;

    [Header("BOOLS:")]
    [SerializeField] bool touchingGround = false;
    [SerializeField] bool hasPressedJump = false;

    [Header("Raycast VARIABLES:")]
    [SerializeField] float circleRadius;

    //REFERENCES
    [Header("REFERENCES:")]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLM;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Jump Input
        if (Input.GetButtonDown("Jump"))
        {
            hasPressedJump = true;
        }
    }

    private void FixedUpdate()
    {
        //Ground check
        Checking();

        //Move
        Move();

        //Jump
        if(touchingGround == true && hasPressedJump == true)
        {
            Jump();
        }
    }

    private void Checking()
    {
        touchingGround = Physics2D.OverlapCircle(groundCheck.position, circleRadius, groundLM);
    }

    private void Move()
    {
        float InputX = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(InputX, 0, 0) * runSpeed * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        Vector2 zeroYVector = rb.velocity;
        zeroYVector.y = 0;
        rb.velocity = zeroYVector;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        hasPressedJump = false;
    }
}
