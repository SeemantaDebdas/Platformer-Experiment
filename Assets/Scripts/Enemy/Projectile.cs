using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 ProjectileDirection { set { projectileDirection = value; } }
    public float ProjectionSpeed { set { projectileSpeed = value; } }
    Vector3 projectileDirection;
    float projectileSpeed;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.velocity = projectileDirection * projectileSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("CameraTrigger")) return;

        if (other.CompareTag("Player"))
        {
            other.GetComponent<Health>().DamagePlayer(10);
        }

        Destroy(this.gameObject);
    }
}
