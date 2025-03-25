using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float thrustPower = 10f;
    public float rotationSpeed = 2f;
    public float maxSpeed = 50f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void Update()
    {
        HandleThrust();
        HandleRotation();
        LimitVelocity();
    }

    void HandleThrust()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * thrustPower, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * thrustPower, ForceMode.Acceleration);
        }
    }

    void HandleRotation()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 rotation = new Vector3(-vertical, horizontal, 0) * rotationSpeed;
        rb.AddTorque(rotation, ForceMode.Acceleration);
    }

    void LimitVelocity()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

}
