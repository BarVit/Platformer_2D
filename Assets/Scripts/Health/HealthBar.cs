using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health Health;

    protected Slider HealthBarSlider;

    protected void Awake()
    {
        HealthBarSlider = GetComponent<Slider>();
    }

    protected void Start()
    {
        HealthBarSlider.value = Health.Value;
    }

    protected void OnEnable()
    {
        Health.Changed += OnHealthChanged;
    }

    protected void OnDisable()
    {
        Health.Changed -= OnHealthChanged;
    }

    public virtual void OnHealthChanged(int health)
    {
        HealthBarSlider.value = (float)health / Health.MaxValue;
    }
}