using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float baseMoveSpeed = 5f;
    public float moveSpeed;
    public float mass = 1;
    public float jumpForce;
    public Transform orientation;

    private Rigidbody rb;
    private bool isGrounded;

    public Animation anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ResetStats();
    }

    public void ResetStats()
    {
        moveSpeed = baseMoveSpeed;
    }

    void Update()
    {
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    public void MovePlayer()
    {
        float speed = moveSpeed;
        Vector3 moveDirection = orientation.forward * Input.GetAxis("Vertical") + orientation.right * Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveDirection.x * speed, rb.velocity.y, moveDirection.z * speed);
        rb.velocity = movement;

        if (moveDirection.magnitude > 0.1f)
        {
            anim.Play("Run");
        }
        else
        {
            anim.Play("Idle");
        }
    }

    public void Jump()
    {
        jumpForce = mass * moveSpeed;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
