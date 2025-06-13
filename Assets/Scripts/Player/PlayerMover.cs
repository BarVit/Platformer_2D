using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 7.5f;
    [SerializeField] private float _speed = 4f;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
    }

    public void Move(float direction)
    {
        _rigidbody2D.velocity = new Vector2(direction * _speed, _rigidbody2D.velocity.y);
    }
}