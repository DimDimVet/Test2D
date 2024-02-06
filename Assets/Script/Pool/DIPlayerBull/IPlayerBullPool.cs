using UnityEngine;

namespace Pools
{
    public interface IPlayerBullPool
    {
        public void AddPull(GameObject prefab, Transform containerTransform);
        public GameObject GetObject(float direction, Transform containerTransform);
        public void ReternObject(int _hash);
    }        

}

