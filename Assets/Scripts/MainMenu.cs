using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene(2);
    }
    public void Credits()
    {
        SceneManager.LoadScene(3);
    }
}
