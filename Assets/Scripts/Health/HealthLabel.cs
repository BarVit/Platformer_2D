using UnityEngine;
using TMPro;

public class HealthLabel : MonoBehaviour
{
    [SerializeField] private TMP_Text _tmpText;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.Changed += ShowHealth;
    }

    private void OnDisable()
    {
        _health.Changed -= ShowHealth;
    }

    private void ShowHealth(int health)
    {
        _tmpText.text = $"Здоровье: {health} / {_health.MaxValue}";
    }
}