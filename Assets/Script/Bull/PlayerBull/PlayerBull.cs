using Pools;
using Zenject;

namespace Bulls
{
    public class PlayerBull : Bull
    {
        private IPlayerBullPool poolBull;
        private IPlayerBull playerBull;
        private IParticlePool particlePool;
        [Inject]
        public void Init(IPlayerBullPool _poolBull, IPlayerBull _playerBull, IParticlePool _particlePool)
        {
            poolBull = _poolBull;
            playerBull = _playerBull;
            particlePool = _particlePool;
        }
        private void OnEnable()
        {
            if (playerBull.DirectionPlayer() > 0) { IsForwardPlus = true; }
            else { IsForwardPlus = false; }
        }
        public override void ReternBullet()
        {
            particlePool.GetObject(playerBull.DirectionPlayer(), this.gameObject.transform);
            poolBull.ReternObject(this.gameObject.GetHashCode());
        }
        public class Factory : PlaceholderFactory<PlayerBull>
        {
        }
    }
}

