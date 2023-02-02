using UnityEngine;

public class RustedTurret : MonoBehaviour
{
    public float ejectionForce;
    public float ejectionTorque;
    public float lifeTime;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Eject();
    }
    public void Eject()
    {
        System.Random random = new System.Random();
        rb.AddForce(new Vector2((float)random.NextDouble(), (float)random.NextDouble()), ForceMode2D.Impulse);
        rb.AddTorque(ejectionTorque);
        Destroy(gameObject, lifeTime);
    }
}
