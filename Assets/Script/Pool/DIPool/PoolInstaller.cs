using Zenject;

namespace Pools
{
    public class PoolInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPoolBull>().To<ExecutorPoolBull>().AsSingle().NonLazy();
        }
    }
}

