using Zenject;

namespace Pools
{
    public class EnemyBullPoolInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IEnemyBullPool>().To<ExecutorEnemyBullPool>().AsSingle().NonLazy();
        }
    }
}
