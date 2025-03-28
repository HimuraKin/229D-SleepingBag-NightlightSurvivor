using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public int maxHealth = 500;
    public int health;
    public float speed = 6f;
    public int damage = 10;
    private Transform player;

    public AudioSource audioSource;
    public AudioClip deadsfx;

    public float attackCooldown = 2f;
    private float lastAttackTime;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        health = maxHealth;
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                HealthSystem playerHealth = collision.gameObject.GetComponent<HealthSystem>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage);
                    lastAttackTime = Time.time;
                }
            }
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
        audioSource.PlayOneShot(deadsfx);
        Destroy(gameObject, 0.5f);
        Invoke("LoadNextScene", 1f);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(2);
    }
}
