using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraHp : MonoBehaviour
{
    public float rotationSpeed;
    public float healthAdded;
    public GameObject healExplosionEffect;
    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed, 0));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerScript playerScript = collision.GetComponent<PlayerScript>();
            if (playerScript.Health + healthAdded > playerScript.maxHealth)
            {
                playerScript.Health = playerScript.maxHealth;
            }
            else
            {
                playerScript.Health += healthAdded;
            }
            Instantiate(healExplosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
