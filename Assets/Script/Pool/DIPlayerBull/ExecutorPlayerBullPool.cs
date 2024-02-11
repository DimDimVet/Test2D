using Bulls;
using Pools;
using UnityEngine;
using Zenject;

public class ExecutorPlayerBullPool : IPlayerBullPool
{
    private Pool pool;
    private IPlayerBull playerBull;
    [Inject]
    private PlayerBull.Factory bullFactory;
    [Inject]
    public void Init( IPlayerBull _playerBull)
    {
        playerBull = _playerBull;
    }

    public void AddPull(GameObject prefab, Transform containerTransform)
    {
        Bull rezult = bullFactory.Create();
        pool = new Pool(rezult.gameObject, containerTransform, true);
    }

    public GameObject GetObject(float direction, Transform containerTransform)
    {
        playerBull.SetDirectionPlayer(direction);
        GameObject tempGameObject = pool.GetObjectFabric(containerTransform);

        if (tempGameObject != null) { return tempGameObject; }
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
