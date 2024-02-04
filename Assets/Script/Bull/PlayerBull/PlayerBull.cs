using Pools;
using Zenject;

namespace Bulls
{
    public class PlayerBull : Bull
    {
        private IPlayerBullPool poolBull;
        private IPlayerBull playerBull;
        [Inject]
        public void Init(IPlayerBullPool _poolBull, IPlayerBull _playerBull)
        {
            poolBull = _poolBull;
            playerBull = _playerBull;
        }
        private void OnEnable()
        {
            if (playerBull.DirectionPlayer() > 0) { IsForwardPlus = true; }
            else { IsForwardPlus = false; }
        }
        public override void ReternBullet()
        {
            poolBull.ReternObject(this.gameObject.GetHashCode());
        }
        public class Factory : PlaceholderFactory<PlayerBull>
        {
        }
    }
}

