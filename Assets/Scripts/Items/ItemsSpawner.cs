using UnityEngine;

[RequireComponent(typeof(ItemPool))]
public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPlaces;
    [SerializeField] private Item _prefab;

    private ItemPool _pool;

    private void Awake()
    {
        _pool = GetComponent<ItemPool>();
        _pool.Init(_prefab);
        Spawn();
    }

    private void Spawn()
    {
        foreach (Transform spawnPlace in _spawnPlaces)
        {
            Item item = _pool.Get();

            item.transform.position = spawnPlace.position;
        }
    }
}