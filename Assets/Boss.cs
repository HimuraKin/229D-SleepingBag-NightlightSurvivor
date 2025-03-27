using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int maxHealth = 300;
    public int health;
    public float speed = 6f;
    public int damage = 10;
    private Transform player;
    public AudioSource audioSource;
    public AudioClip deadsfx;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        health = maxHealth; // กำหนดค่า Health เริ่มต้น
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            audioSource.PlayOneShot(deadsfx);
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject, 0.5f);
    }
}
