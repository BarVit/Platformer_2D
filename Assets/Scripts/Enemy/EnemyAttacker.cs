using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyMover))]
public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private float _hitRangeX = 1f;
    [SerializeField] private float _hitRate = 1.1f;
    [SerializeField] private EnemyAnimator _animator;
    [SerializeField] private FaceDirectioneer _spriteDirection;

    private EnemyMover _mover;
    private Player _target;
    private float _cooldown = 0;
    private int _direction = 0;
    private int _nonDirection = 0;
    private bool _isAttacking = false;
    private bool _isAttackEnded = true;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
    }

    private void Update()
    {
        if (_isAttacking && _target != null)
        {
            DefineDirection();
            _spriteDirection.SetFaceDirection(_direction);

            if (IsInHitRange() && _isAttackEnded)
                StartCoroutine(Hit());
            else if (_isAttackEnded)
                Approach();
        }
    }

    public void StartAttack(Player player)
    { 
        _target = player;
        _isAttacking = true;
    }

    public void StopAttack()
    {
        _target = null;
        _isAttacking = false;
    }

    private bool IsInHitRange()
    {
        return Mathf.Abs(transform.position.x - _target.transform.position.x) < _hitRangeX;
    }

    private void DefineDirection()
    {
        int leftDirection = -1;
        int rightDirection = 1;

        if (transform.position.x > _target.transform.position.x && IsInHitRange() == false)
            _direction = leftDirection;
        else if (transform.position.x < _target.transform.position.x && IsInHitRange() == false)
            _direction = rightDirection;
        else
            _direction = _nonDirection;
    }

    private IEnumerator Hit()
    {
        _mover.Stop();
        _animator.SetSpeed(0);
        _animator.Attack();
        _isAttackEnded = false;
        _cooldown = _hitRate;

        while (_cooldown > 0)
        {
            _cooldown -= Time.deltaTime;
            
            yield return null;
        }

        _isAttackEnded = true;
    }

    private void Approach()
    {
        _mover.Move(_direction);

        if (_direction == _nonDirection)
            _animator.SetSpeed(0);
        else
            _animator.SetSpeed(_mover.Speed);
    }
}