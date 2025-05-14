using System;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    public event Action Attacking;

    public void InvokeAttackEvent() => Attacking?.Invoke();
}