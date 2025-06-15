using UnityEngine;

[RequireComponent(typeof(Health), typeof(PlayerActivity))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerDeadBody _playerDeadBody;
    [SerializeField] private FaceDirectioneer _faceRotation;

    private Health _health;
    private PlayerActivity _playerActivity;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _playerActivity = GetComponent<PlayerActivity>();
    }

    private void OnEnable()
    {
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
    }

    private void Update()
    {
        _playerActivity.Run();
    }

    private void Die()
    {
        PlayerDeadBody playerDeadBody = Instantiate(_playerDeadBody);

        playerDeadBody.gameObject.SetActive(true);
        playerDeadBody.transform.SetPositionAndRotation(transform.position, _faceRotation.transform.rotation);
        playerDeadBody.Die();
        gameObject.SetActive(false);
    }
}