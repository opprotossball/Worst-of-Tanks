using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    public Transform target;
    public Transform firePoint;
    public GameObject turretParent;
    public Turret turret;
    public EnemyHealthBar healthBar;
    public GameObject bulletPrefab;
    public GameObject wreckPrefab;
    public GameObject bigExplosionPrefab;
    public GameObject rustedTurretPrefab;
    public float shootRange;
    public float speed;
    public float minDistance;
    public float maxHealth;
    public float collisionDamage;
    public float reloadTime;
    public float bulletSpeed = 20f;
    public float sightDistance;
    public float explosionDelay;
    private float reloadTimeElapsed = 0;
    private bool readyToShoot = true;
    private int shootLayerMask;
    private Side turretRotationDirection;
    private AudioSource shotSound;
    Rigidbody rb;
    private float health;
    enum Side
    {
        Left,
        Right
    }
    public float Health
    {
        get { return health; }
        set
        {
            if (value <= 0)
            {
                Destroyed(explosionDelay);
            }
            healthBar.SetValue(value, maxHealth);
            health = value;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            float damage = (float)Math.Pow(other.relativeVelocity.magnitude, 2) * collisionDamage;
            Health -= damage;
            PlayerScript playerScript = other.gameObject.GetComponent<PlayerScript>();
            playerScript.Health -= damage;
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = maxHealth;
        turret = turretParent.GetComponent<Turret>();
        shootLayerMask = LayerMask.GetMask("Player");
        Array sides = Enum.GetValues(typeof(Side));
        System.Random random = new System.Random();
        turretRotationDirection = (Side)sides.GetValue(random.Next(sides.Length));
        shotSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(target == null)
        {
            return;
        }
        if(Vector2.Distance(transform.position, target.position) > sightDistance)
        {
            return;
        }
        if(turretRotationDirection == Side.Left)
        {
            turret.RotateLeft();
        }
        else if(turretRotationDirection == Side.Right)
        {
            turret.RotateRight();
        }
        if (Vector2.Distance(transform.position, target.position) > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        Vector2 direction = target.position - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        if (readyToShoot)
        {
            if (Physics2D.Raycast(firePoint.position, turretParent.transform.TransformDirection(Vector2.up), shootRange, shootLayerMask))
            {
                shotSound.Play();
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.velocity = (firePoint.up * bulletSpeed);
                Destroy(bullet, 5f);
                readyToShoot = false;
            }
        }
        else 
        {
            if (reloadTimeElapsed >= reloadTime)
            {
                readyToShoot = true;
                reloadTimeElapsed = 0;
            }
            else
            {
                reloadTimeElapsed += Time.deltaTime;
            }
        }
        turret.OnUpdate();
    }
    private IEnumerator WaitAndDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(bigExplosionPrefab, transform.position, transform.rotation);
        Instantiate(wreckPrefab, transform.position, transform.rotation);
        Instantiate(rustedTurretPrefab, transform.position, transform.rotation);
        FindObjectOfType<AudioManager>().Play("Explosion");
        Destroy(gameObject);
    }
    public void Destroyed(float time)
    {
        StartCoroutine(WaitAndDestroy(time));
    }
}
