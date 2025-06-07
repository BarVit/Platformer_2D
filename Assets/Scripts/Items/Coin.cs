using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Coin : Item
{
    private int _minValue = 1;
    private int _maxValue = 4;
    private int _idleHash = Animator.StringToHash("Idle");

    public int Value { get; private set; }

    private void Awake()
    {
        GetComponent<Animator>().Play(_idleHash, 0, 0.5f);
        Value = Random.Range(_minValue, _maxValue + 1);
    }

    public override void Pick(ICollector pickable)
    {
        base.Pick(pickable);
        pickable.Collect(this);
    }
}