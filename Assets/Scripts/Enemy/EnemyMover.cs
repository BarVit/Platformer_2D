using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    [field: SerializeField] public float Speed { get; private set; }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Speed = 2f;
    }

    public void Move(int direction)
    {
        _rigidbody2D.velocity = new Vector2(direction * Speed, _rigidbody2D.velocity.y);
    }

    public void Stop()
    {
        _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
    }
}