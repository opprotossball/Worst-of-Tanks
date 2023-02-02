using UnityEngine;
using UnityEngine.UI;
public class ReloadBar : MonoBehaviour
{
    public ReloadBar reloadBar;
    public Image fill;
    private Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
    }
    public void SetValue(float timeElapsed, float reloadTime)
    {
        slider.value = timeElapsed / reloadTime;
    }
}
