using UnityEngine;

namespace Pools
{
    public interface IEnemyBullPool
    {
        public void AddPull(GameObject prefab, Transform containerTransform);
        public GameObject GetObject(float direction);
        public void ReternObject(int _hash);
    }

}
