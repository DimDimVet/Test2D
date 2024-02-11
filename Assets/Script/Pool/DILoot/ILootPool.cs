using UnityEngine;

namespace Pools
{
    public interface ILootPool
    {
        public GameObject GetObject(float direction, Transform containerTransform);
        public void ReternObject(int _hash);
    }
}
