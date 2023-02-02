using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelChooser : MonoBehaviour
{
    public int index;
    public void Back()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(index + 4);
    }
}
