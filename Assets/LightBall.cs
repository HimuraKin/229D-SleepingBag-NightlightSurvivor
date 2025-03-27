using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBall : MonoBehaviour
{
    public int baseDamage = 30;
    public float lifeTime = 5f;
    public int damage;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void ResetStats()
    {
        damage = baseDamage;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            Boss boss = other.gameObject.GetComponent<Boss>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
            else if (boss != null)
            {
                boss.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }

}
