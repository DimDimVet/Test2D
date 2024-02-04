using Pools;
using Zenject;

namespace Bulls
{
    public class EnemyBull : Bull
    {
        private IEnemyBullPool poolBull;
        private IEnemyBull enemyBull;
        [Inject]
        public void Init(IEnemyBullPool _poolBull, IEnemyBull _enemyBull)
        {
            poolBull = _poolBull;
            enemyBull = _enemyBull;
        }
        private void OnEnable()
        {
            if (enemyBull.DirectionPlayer() > 0) { IsForwardPlus = true; }
            else { IsForwardPlus = false; }
        }
        public override void ReternBullet()
        {
            poolBull.ReternObject(this.gameObject.GetHashCode());
        }
        public class Factory : PlaceholderFactory<EnemyBull>
        {
        }
    }
}

