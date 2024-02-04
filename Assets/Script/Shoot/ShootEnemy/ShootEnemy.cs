using Pools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Shoot
{
    public class ShootEnemy : Shoot
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform poolTransform;

        private IEnemyBullPool poolBull;
        [Inject]
        public void Init(IEnemyBullPool _poolBull)
        {
            poolBull = _poolBull;
        }
        public override void Set()
        {
            poolBull.AddPull(prefab, poolTransform);
        }
        public override void ShootBullet()
        {
            //CurrentCountClip--;

            poolBull.GetObject(gameObject.transform.localScale.x);
        }
        public override void ShootBulletSleeve()
        {
        }
    }
}

