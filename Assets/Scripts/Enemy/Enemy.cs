using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyStateMachine _stateMachine;
    [SerializeField] private EnemyDeadBody _enemyDeadBody;

    private Health _health;

    [field : SerializeField] public Transform[] Waypoints { get; private set; }
    [field : SerializeField] public EnemyAnimator Animator { get; private set; }
    [field : SerializeField] public AttackAnimationHandler AnimationHandler { get; private set; }
    [field : SerializeField] public FaceDirectioneer SpriteDirection { get; private set; }
    [field : SerializeField] public EnemyMover Mover { get; private set; }
    [field : SerializeField] public TargetFinder TargetFinder { get; private set; }

    private void Awake()
    {
        _health = GetComponent<Health>();
        _stateMachine.Activate(this);
    }

    private void OnEnable()
    {
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
    }

    private void Die()
    {
        EnemyDeadBody enemyDeadBody = Instantiate(_enemyDeadBody);

        enemyDeadBody.gameObject.SetActive(true);
        enemyDeadBody.transform.SetPositionAndRotation(transform.position, SpriteDirection.transform.rotation);
        enemyDeadBody.Die();
        _stateMachine.Stop();
        gameObject.SetActive(false);
    }
}