using Pools;
using UnityEngine;
using Zenject;

namespace Shoot
{
    public class ShootPlayer : Shoot
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform poolTransform;

        private IPoolBull poolBull;
        [Inject]
        public void Init(IPoolBull pb)
        {
            poolBull = pb;
        }

        public override void Set()
        {
            poolBull.AddPull(prefab, poolTransform);
        }
        public override void ShootBullet()
        {
            CurrentCountClip--;
            poolBull.GetObject();
        }
        public override void ShootBulletSleeve()
        {
        }

    }
}


