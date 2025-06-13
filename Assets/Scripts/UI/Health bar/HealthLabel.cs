using UnityEngine;
using TMPro;

public class HealthLabel : UI_Health
{
    [SerializeField] private TMP_Text _tmpText;

    public override void OnHealthChanged(int health)
    {
        _tmpText.text = $"Здоровье: {health} / {Health.MaxValue}";
    }
}