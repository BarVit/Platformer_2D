using System;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public event Action<Item> Picked;

    public virtual void Pick(ICollector pickable)
    {
        Picked?.Invoke(this);
    }
}