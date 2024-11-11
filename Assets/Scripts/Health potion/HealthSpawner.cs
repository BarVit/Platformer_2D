using UnityEngine;
using UnityEngine.Pool;

public class HealthSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPlaces;
    [SerializeField] private HealthPotion _healthPotion;

    private ObjectPool<HealthPotion> _pool;
    private int _poolCapacity = 10;
    private int _poolMaxSize = 100;

    private void Awake()
    {
        InitializePool();
        SpawnHealthPotions();
    }

    private void InitializePool()
    {
        _pool = new ObjectPool<HealthPotion>(
            createFunc: () => Instantiate(_healthPotion),
            actionOnGet: (obj) => obj.gameObject.SetActive(true),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    private void Release(HealthPotion healthPotion)
    {
        healthPotion.Taken -= Release;
        _pool.Release(healthPotion);
    }

    private void SpawnHealthPotions()
    {
        foreach (Transform spawnPlace in _spawnPlaces)
        {
            HealthPotion healthpotion = _pool.Get();

            healthpotion.Taken += Release;
            healthpotion.transform.position = spawnPlace.position;
        }
    }
}