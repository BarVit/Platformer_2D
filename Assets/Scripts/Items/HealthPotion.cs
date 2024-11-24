using UnityEngine;

public class HealthPotion : Item
{
    [field: SerializeField] public int HealingAmount { get; private set; } = 10;
}