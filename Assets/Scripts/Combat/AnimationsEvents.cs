using System;
using UnityEngine;

public class AnimationsEvents : MonoBehaviour
{
    public event Action Attacking;

    public void InvokeAttackEvent() => Attacking?.Invoke();
}