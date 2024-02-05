using EnemyLogic;
using Pools;
using RegistratorObject;
using UnityEngine;
using Zenject;

namespace Shoot
{
    public class ShootEnemy : Shoot
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform poolTransform;
        private Construction[] targets;

        private IEnemyBullPool poolBull;
        private IScanerExecutor scanerExecutor;
        [Inject]
        public void Init(IEnemyBullPool _poolBull, IScanerExecutor s)
        {
            poolBull = _poolBull;
            scanerExecutor = s;
        }
        public override void Set()
        {
            poolBull.AddPull(prefab, poolTransform);
        }
        public override void ShootBullet()
        {
            //CurrentCountClip--;
            if (Target()) { poolBull.GetObject(gameObject.transform.localScale.x); }
            Debug.Log(Target());

        }
        private bool Target()
        {
            if (targets == null) { targets = scanerExecutor.GetRezultScaner(); return false; }
            else
            {
                for (int i = 0; i < targets.Length; i++)
                {
                    if (targets[i].Hash != 0) { return true; }
                }
            }
            return false;
        }
        public override void ShootBulletSleeve()
        {
        }
    }
}

