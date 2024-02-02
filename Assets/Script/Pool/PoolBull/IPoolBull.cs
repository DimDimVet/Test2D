using UnityEngine;

namespace Pools
{
    public interface IPoolBull
    {
        public void AddPull(GameObject prefab, Transform containerTransform);
        public GameObject GetObject();
        public GameObject GetObjectHit(RaycastHit hit);
        public GameObject GetObjectRandomPosition(Vector3 pointDefault, float range);
        public bool ReternObject(int _hash);

    }
}

