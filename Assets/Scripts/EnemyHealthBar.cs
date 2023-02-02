using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    public Transform enemy;
    public Transform bar;
    public void SetValue(float health, float maxHealth)
    {
        float healthNormalized;
        if (health > maxHealth)
        {
            healthNormalized = 1f;
        }
        else if (health < 0)
        {
            healthNormalized = 0;
        }
        else
        {
            healthNormalized = health / maxHealth;
        }
        bar.localScale = new Vector3(healthNormalized, 1f);
    }
    private void Update()
    {
        transform.eulerAngles = Vector3.zero;
        transform.position = new Vector3(enemy.position.x, enemy.position.y + 1.5f , 0f);
    }
}
