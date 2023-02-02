using UnityEngine;

public class Turret : MonoBehaviour
{
    public float rotationSpeed = 150f;
    public float explosionForce;
    private Transform tr;
    private bool rotatingLeft, rotatingRight;
    private Rigidbody2D rb;
    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }
    public void RotateLeft()
    {
        if (rotatingRight)
        {
            rotatingRight = false;
        }
        else
        {
            rotatingLeft = true;
        }
    }
    public void RotateRight()
    {
        if (rotatingLeft)
        {
            rotatingLeft = false;
        }
        else
        {
            rotatingRight = true;
        }
    }
    public void StopRotation()
    {
        rotatingLeft = false;
        rotatingRight = false;
    }
    public void EjectTurret()
    {
        System.Random random = new System.Random();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(new Vector2((float)random.NextDouble(), (float)random.NextDouble()) * explosionForce, ForceMode2D.Impulse);
    }
    internal void OnUpdate()
    {
        if (rotatingLeft)
        {
            tr.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));

        }
        else if (rotatingRight)
        {
            tr.Rotate(new Vector3(0, 0, -rotationSpeed * Time.deltaTime));
        }
    }
}
