using Pools;
using UnityEngine;
using Zenject;

namespace Shoot
{
    public class ShootPlayer : Shoot
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform poolTransform;
        [SerializeField] private ParticleSystem particle;

        private IPlayerBullPool poolBull;
        [Inject]
        public void Init(IPlayerBullPool _poolBull)
        {
            poolBull = _poolBull;
        }
        public override void Set()
        {
            poolBull.AddPull(prefab, poolTransform);
        }
        public override void ShootBullet()
        {
            particle.Play();
            poolBull.GetObject(gameObject.transform.localScale.x, poolTransform);
        }
        public override void ShootBulletSleeve()
        {
        }

    }
}


