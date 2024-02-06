using Bulls;
using Pools;
using UnityEngine;
using Zenject;

public class ExecutorEnemyBullPool : IEnemyBullPool
{
    private Pool pool;
    private IEnemyBull enemyBull;
    [Inject]
    private EnemyBull.Factory bullFactory;
    [Inject]
    public void Init(IEnemyBull _enemyBull)
    {
        enemyBull = _enemyBull;
    }

    private void AddPull(Transform containerTransform)
    {
        Bull rezult = bullFactory.Create();
        //pool = new Pool(prefab, containerTransform);
        pool = new Pool(rezult.gameObject, containerTransform, true);
    }

    public GameObject GetObject(float direction, Transform containerTransform)
    {
        if (pool == null) { AddPull(containerTransform); }
        Vector3 vector = containerTransform.position;
        enemyBull.SetDirectionPlayer(direction);
        if (pool.GetObjectFabric(containerTransform) != null) { return pool.GetObjectFabric(containerTransform); }
        else
        {
            Bull rezult = bullFactory.Create();
            pool.NewObjectQueue(rezult.gameObject);
            return pool.GetObjectFabric(containerTransform);
        }
    }

    public void ReternObject(int _hash)
    {
        pool.ReternObject(_hash);
    }

}