using Zenject;

namespace Pools
{
    public class PlayerBullPoolInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPlayerBullPool>().To<ExecutorPlayerBullPool>().AsSingle().NonLazy();
        }
    }
}

