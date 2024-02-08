using Pools;
using Zenject;

namespace Loot
{
    public class ExecutorLootPool
    {
        private Pool pool;
        private IHealtLoot healtLoot;
        [Inject]
        private HealtLoot.Factory healtLootFactory;
        [Inject]
        public void Init(IHealtLoot _healtLoot)
        {
            healtLoot = _healtLoot;
        }
    }
}

