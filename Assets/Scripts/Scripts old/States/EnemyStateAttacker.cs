using System;
using System.Collections;
using UnityEngine;

public class EnemyStateAttacker : EnemyState2
{
    [SerializeField] private AnimationClip _attackAnimation;

    private Coroutine _animationWaiter;

    public override void Enter(Player target)
    {
        Target = target;

        if(IsBlocked == false)
        {
            _animationWaiter = StartCoroutine(WaitAnimation());
            IsBlocked = true;
            Animator.Attack();
        }
    }

    public override void Exit()
    {
        Target = null;
    }

    private IEnumerator WaitAnimation()
    {
        WaitForSeconds timeToWait = new WaitForSeconds(_attackAnimation.length);

        yield return timeToWait;

        IsBlocked = false;
    }
}