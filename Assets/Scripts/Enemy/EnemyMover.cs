using UnityEngine;

[RequireComponent(typeof(FaceDirectioneer), typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    private FaceDirectioneer _faceDirectioneer;
    private Rigidbody2D _rigidbody2D;

    [field : SerializeField] public float Speed = 2.0f;

    private void Awake()
    {
        _faceDirectioneer = GetComponent<FaceDirectioneer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetFaceDirection(int direction)
    {
        _faceDirectioneer.SetFaceDirection(transform, direction);
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