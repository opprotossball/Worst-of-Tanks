using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject turretParent;
    public GameObject wreckPrefab;
    public GameObject bigExplosionPrefab;
    public PlayerController playerController;
    public PlayerMove playerMove;
    public Turret turret;
    public PlayerShoot playerShoot;
    public HealthBar healthBar;
    public GameObject rustedTurretPrefab;
    public float maxHealth;
    private float health;

    private IEnumerator WaitAndDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        FindObjectOfType<GameHandler>().Defeat();
        Instantiate(bigExplosionPrefab, transform.position, transform.rotation);
        Instantiate(wreckPrefab, transform.position, transform.rotation);
        Instantiate(rustedTurretPrefab, transform.position, transform.rotation);
        FindObjectOfType<AudioManager>().Play("Explosion");
        Destroy(gameObject);
    }
    public float Health
    {
        get { return health; }
        set 
        { 
            if (value <= 0)
            {
                StartCoroutine(WaitAndDestroy(0.2f));
            }
            health = value;
            healthBar.SetValue(value, maxHealth);
        }
    }
    private void Start()
    {
        health = maxHealth;
        turret = turretParent.GetComponent<Turret>();
    }
    private void Update()
    {
        playerController.OnUpdate();
        turret.OnUpdate();
        playerShoot.OnUpdate();
    }
    private void FixedUpdate()
    {
        playerMove.OnFixedUpdate();
    }
    private void Destroyed(float time)
    {
        StartCoroutine(WaitAndDestroy(time));
    }
}
