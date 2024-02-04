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

    public void AddPull(GameObject prefab, Transform containerTransform)
    {
        Bull rezult = bullFactory.Create();
        //pool = new Pool(prefab, containerTransform);
        pool = new Pool(rezult.gameObject, containerTransform, true);
    }

    public GameObject GetObject(float direction)
    {
        enemyBull.SetDirectionPlayer(direction);
        if (pool.GetObjectFabric() != null) { return pool.GetObjectFabric(); }
        else
        {
            Bull rezult = bullFactory.Create();
            pool.NewObjectQueue(rezult.gameObject);
            return pool.GetObjectFabric();
        }
    }

    public void ReternObject(int _hash)
    {
        pool.ReternObject(_hash);
    }

}