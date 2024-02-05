using Zenject;

namespace EnemyLogic
{
    public class ScanerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IScanerExecutor>().To<ScanerExecutor>().AsSingle().NonLazy();
        }
    }
}

