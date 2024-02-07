using Zenject;

namespace UI
{
    public class LogicMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ILogicMenu>().To<LogicMenuExecutor>().AsSingle().NonLazy();
        }
    }
}

