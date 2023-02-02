using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public GameObject victoryText;
    public GameObject defeatText;
    public Image shade;
    public float maxEnemyExplosionDelay = 1f;
    public float delay;
    public float shadeAlpha;
    private List<GameObject> enemies;
    IEnumerator WaitAndExit(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(0);
        FindObjectOfType<AudioManager>().Play("MainTheme");
    }
    private void Shade()
    {
        var color = shade.color;
        color.a = shadeAlpha;
        shade.color = color;
    }
    private void Start()
    {
        victoryText.SetActive(false);
        defeatText.SetActive(false);  
        enemies = new List<GameObject>();
        enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
    }
    public void Victory()
    {
        FindObjectOfType<AudioManager>().StopAll();
        FindObjectOfType<AudioManager>().Play("Success");
        victoryText.SetActive(true);
        System.Random random = new System.Random();
        foreach(GameObject enemy in enemies)
        {
            if (enemy == null)
            {
                continue;
            }
            EnemyScript enemyScript = enemy.GetComponent<EnemyScript>();
            if (enemyScript == null)
            {
                continue;
            }
            if (enemyScript.target != null)
            {
                float time = (float)(random.NextDouble() * maxEnemyExplosionDelay);
                enemyScript.Destroyed(time);
            }
        }
        StartCoroutine(WaitAndExit(delay));
        Shade();
    }
    public void Defeat()
    {
        FindObjectOfType<AudioManager>().StopAll();
        FindObjectOfType<AudioManager>().Play("Defeat");
        defeatText.SetActive(true);
        StartCoroutine(WaitAndExit(delay));
        Shade();
    }
}
