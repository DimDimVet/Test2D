using Pools;
using Zenject;

namespace Bulls
{
    public class EnemyBull : Bull
    {
        private IEnemyBullPool poolBull;
        private IEnemyBull enemyBull;
        private IParticlePool particlePool;
        [Inject]
        public void Init(IEnemyBullPool _poolBull, IEnemyBull _enemyBull,IParticlePool _particlePool)
        {
            poolBull = _poolBull;
            enemyBull = _enemyBull;
            particlePool = _particlePool;
        }
        private void OnEnable()
        {
            if (enemyBull.DirectionPlayer() > 0) { IsForwardPlus = true; }
            else { IsForwardPlus = false; }
        }
        public override void ReternBullet()
        {
            particlePool.GetObject(enemyBull.DirectionPlayer(), this.gameObject.transform);
            poolBull.ReternObject(this.gameObject.GetHashCode());
        }
        public class Factory : PlaceholderFactory<EnemyBull>
        {
        }
    }
}

