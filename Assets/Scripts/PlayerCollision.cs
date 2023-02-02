using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    public PlayerScript playerScript;
    public float barricadeCollisionDamage;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerScript.Health -= barricadeCollisionDamage * (float)Math.Pow(collision.relativeVelocity.magnitude, 2);
        }
    }
}
