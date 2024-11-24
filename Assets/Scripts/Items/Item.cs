using UnityEngine;
using System;

public abstract class Item : MonoBehaviour
{
    public event Action<Item> Taken;

    public void Take()
    {
        Taken?.Invoke(this);
    }
}