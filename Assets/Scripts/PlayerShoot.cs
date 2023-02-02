using UnityEngine;
public class PlayerShoot : MonoBehaviour
{
    public PlayerScript playerScript;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public ReloadBar reloadBar;
    public float reloadTime;
    public float bulletSpeed = 20f;
    private float reloadTimeElapsed = 0;
    private bool readyToShoot = true;
    
    public void Shoot()
    {
        playerScript.turret.StopRotation();
        if (readyToShoot)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = (firePoint.up * bulletSpeed);
            Destroy(bullet, 5f);
            readyToShoot = false;
            FindObjectOfType<AudioManager>().Play("ShotSound");
        }
    }
    public void OnUpdate()
    {
        if (readyToShoot)
        {
            return;
        }
        if (reloadTimeElapsed >= reloadTime)
        {
            readyToShoot = true;
            reloadTimeElapsed = 0;
            reloadBar.SetValue(reloadTime, reloadTime);
        }
        else
        {
            reloadTimeElapsed += Time.deltaTime;
            reloadBar.SetValue(reloadTimeElapsed, reloadTime);
        }
    }
}