using Pools;
using UnityEngine;

public class ExecutorPoolBull : IPoolBull
{
    private Pool pool;

    public void AddPull(GameObject prefab, Transform containerTransform)
    {
        pool = new Pool(prefab, containerTransform);
    }

    public GameObject GetObject()
    {
        return pool.GetObject();
    }

    public GameObject GetObjectHit(RaycastHit hit)
    {
        return pool.GetObjectHit(hit);
    }

    public GameObject GetObjectRandomPosition(Vector3 pointDefault, float range)
    {
        return GetObjectRandomPosition(pointDefault, range);
    }

    public bool ReternObject(int _hash)
    {
        return ReternObject(_hash);
    }
}
