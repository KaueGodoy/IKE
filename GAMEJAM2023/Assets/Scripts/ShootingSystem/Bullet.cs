using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;

    [Header("Speed")]
    public float bulletSpeed = 10f;

    [Header("Damage")]
    public float bulletDamage = 5f;
    public float critRate = 30f;

    [Header("Distance")]
    public float timeToDestroy = 3f;

    void Start()
    {
        rb.velocity = transform.right * bulletSpeed; 
    }

    private void Update()
    {
        Destroy(this.gameObject, timeToDestroy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if(enemy != null)
        {
           
            bool isCritical = UnityEngine.Random.Range(0, 100) < critRate;

            if(isCritical)
            {
                bulletDamage *= 2;
            }

            enemy.TakeDamage(bulletDamage);
            DamagePopup.Create(transform.position, (int) bulletDamage, isCritical);
        }

        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
