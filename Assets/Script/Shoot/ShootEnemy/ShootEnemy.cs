using EnemyLogic;
using Pools;
using RegistratorObject;
using UnityEngine;
using Zenject;

namespace Shoot
{
    public class ShootEnemy : Shoot
    {
        [SerializeField] private Transform poolTransform;
        [SerializeField] private ParticleSystem particle;
        private Construction[] targets;
        private IEnemyBullPool poolBull;
        private IScanerExecutor scanerExecutor;
        [Inject]
        public void Init(IEnemyBullPool _poolBull, IScanerExecutor s)
        {
            poolBull = _poolBull;
            scanerExecutor = s;
        }
        public override void ShootBullet()
        {
            if (Target()) { particle.Play(); poolBull.GetObject(gameObject.transform.localScale.x, poolTransform); }
        }
        private bool Target()
        {
            if (targets == null) { targets = scanerExecutor.GetRezultScaner(ThisHash); return false; }
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

