using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPlaces;
    [SerializeField] private Coin _coin;

    private ObjectPool<Coin> _pool;
    private int _poolCapacity = 10;
    private int _poolMaxSize = 100;

    private void Awake()
    {
        InitializePool();
        SpawnCoins();
    }

    private void InitializePool()
    {
        _pool = new ObjectPool<Coin>(
            createFunc: () => Instantiate(_coin),
            actionOnGet: (obj) => obj.gameObject.SetActive(true),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    private void Release(Coin coin)
    {
        coin.Taken -= Release;
        _pool.Release(coin);
    }

    private void SpawnCoins()
    {
        foreach (Transform spawnPlace in _spawnPlaces)
        {
            Coin coin = _pool.Get();

            coin.Taken += Release;
            coin.transform.position = spawnPlace.position;
        }
    }
}