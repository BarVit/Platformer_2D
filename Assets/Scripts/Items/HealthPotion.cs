using UnityEngine;

public class HealthPotion : Item
{
    [field: SerializeField] public int HealingAmount { get; private set; } = 10;

    public override void Pick(IPickable pickable)
    {
        base.Pick(pickable);
        pickable.Pick(this);
    }
}