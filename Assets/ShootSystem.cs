using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{
    public GameObject lightBallPrefab;
    public Transform shootPoint;
    public float mass = 2f;
    public float acceleration = 50f;
    public float fireRate = 0.5f;

    private float nextFireTime = 0f;

    void Update()
    {
        ShootLightBall();
    }

    void ShootLightBall()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;

            GameObject ball = Instantiate(lightBallPrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            float shootForce = mass * acceleration;

            if (rb != null)
            {
                rb.AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);
            }
        }
    }
}
