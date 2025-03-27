using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{
    public GameObject lightBallPrefab;
    public Transform shootPoint;
    public float mass = 2f;
    public float acceleration = 50f;
    public float fireRate;
    public float baseFireRate = 1f;

    private float nextFireTime = 0f;
    public GameObject upgradePanel;

    public AudioSource AudioSource;
    public AudioClip shootVfx;

    void Start()
    {
        ResetStats();
    }

    public void ResetStats()
    {
        fireRate = baseFireRate;
    }

    void Update()
    {
        ShootLightBall();
    }

    void ShootLightBall()
    {
        if ( (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime) && !upgradePanel.activeSelf)
        {
            nextFireTime = Time.time + fireRate;

            GameObject ball = Instantiate(lightBallPrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            float shootForce = mass * acceleration;
            AudioSource.PlayOneShot(shootVfx);

            if (rb != null)
            {
                rb.AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);
            }
        }
    }
}
