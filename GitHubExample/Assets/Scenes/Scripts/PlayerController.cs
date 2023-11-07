using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;
    private Vector3 moveDirection;
    public float gravityScale;
    
    public float knockBackForce;
    public float knockBackTime;
    private float knockBackCounter;

    private bool isJumping = false;
    private float jumpBufferTime = 0.1f; // Time in seconds to buffer the jump
    private float jumpBufferCounter;

    // Start is called before the first frame update
    void Start() {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (knockBackCounter <= 0)
        {
            if (controller.isGrounded)
            {
                moveDirection.y = 0f;
            }

            moveDirection.x = Input.GetAxis("Horizontal") * moveSpeed;
            moveDirection.z = Input.GetAxis("Vertical") * moveSpeed;
            moveDirection = transform.TransformDirection(moveDirection);


            if (controller.isGrounded && Input.GetButtonDown("Jump"))
            {
                isJumping = true;
                jumpBufferCounter = jumpBufferTime;
            }
            
            if (jumpBufferCounter > 0)
            {
                jumpBufferCounter -= Time.deltaTime;
            }
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (knockBackCounter <= 0)
        {
            if (isJumping && jumpBufferCounter > 0)
            {
                moveDirection.y = jumpForce;
                isJumping = false;
            }

            moveDirection.y += (Physics.gravity.y * gravityScale * Time.fixedDeltaTime);
            controller.Move(moveDirection * Time.fixedDeltaTime);
        }
    }

    public void Knockback(Vector3 direction)
    {
        knockBackCounter = knockBackTime;
        moveDirection = direction * knockBackForce;
        moveDirection.y = knockBackForce;
    }
}
