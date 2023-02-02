using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage;
    public GameObject explosionEffectPrefab;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Hit");
            PlayerScript playerScript = other.GetComponent<PlayerScript>();
            playerScript.Health -= bulletDamage;
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if(other.CompareTag("Enemy"))
        {
            FindObjectOfType<AudioManager>().Play("Hit");
            EnemyScript enemyScript = other.GetComponent<EnemyScript>();
            enemyScript.Health -= bulletDamage;
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if(other.CompareTag("Walls") || other.CompareTag("Wreck"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Walls") || other.CompareTag("Wreck"))
        {
            Destroy(gameObject);
        }
    }
}
