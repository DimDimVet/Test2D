using Pools;
using RegistratorObject;
using Zenject;

namespace Loot
{
    public class HealtLoot : Loot
    {
        private ILootPool poolLoot;
        [Inject]
        public void Init(ILootPool _poolLoot)
        {
            poolLoot = _poolLoot;
        }
        public override void Executor(Construction player)
        {
            if (player.TypeObject == TypeObject.Player)
            {
                player.HealtPlayer.Healing(player.Hash, Healt);
            }
        }
        public override void ReternLoot()
        {
            poolLoot.ReternObject(this.gameObject.GetHashCode());
        }
        public class Factory : PlaceholderFactory<HealtLoot>
        {
        }
    }
}

