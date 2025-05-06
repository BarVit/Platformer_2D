using System;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public event Action AnimationEnded;

    public void StopAttackAnimation()
    {
        AnimationEnded?.Invoke();
    }
}