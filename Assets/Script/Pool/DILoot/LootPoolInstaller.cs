using Zenject;

namespace Pools
{
    public class LootPoolInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ILootPool>().To<ExecutorLootPool>().AsSingle().NonLazy();
        }
    }
}

