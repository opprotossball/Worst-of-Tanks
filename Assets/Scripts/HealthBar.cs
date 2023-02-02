using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Gradient gradient;
    private Slider slider;
    public Image fill;
    void Start()
    {
        slider = GetComponent<Slider>();
        fill.color = gradient.Evaluate(1);
    }
    public void SetValue(float health, float maxHealth)
    {
        slider.value = health / maxHealth;
        fill.color = gradient.Evaluate(health / maxHealth);
    }
}
