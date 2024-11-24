using UnityEngine;
using UnityEngine.Pool;

public class ItemPool : MonoBehaviour
{
    private Item _prefab;
    private ObjectPool<Item> _pool;
    private int _poolCapacity = 10;
    private int _poolMaxSize = 100;

    public void Init(Item prefab)
    {
        _prefab = prefab;
        InitializePool();
    }

    private void InitializePool()
    {
        _pool = new ObjectPool<Item>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (item) => item.gameObject.SetActive(true),
            actionOnRelease: (item) => item.gameObject.SetActive(false),
            actionOnDestroy: (item) => Destroy(item),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    public Item Get()
    {
        Item item = _pool.Get();

        item.Taken += Realese;
        return item;
    }

    public void Realese(Item item)
    {
        item.Taken -= Realese;
        _pool.Release(item);
    }
}