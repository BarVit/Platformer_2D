using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : UI_Health
{
    protected Slider HealthBarSlider;

    protected void Awake()
    {
        HealthBarSlider = GetComponent<Slider>();
    }

    protected void Start()
    {
        HealthBarSlider.value = Health.Value;
    }

    public override void OnHealthChanged(int health)
    {
        HealthBarSlider.value = (float)health / Health.MaxValue;
    }
}