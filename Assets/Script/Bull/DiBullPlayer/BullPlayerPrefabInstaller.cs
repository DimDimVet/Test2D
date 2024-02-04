using Zenject;

namespace Bulls
{
    public class BullPlayerPrefabInstaller : MonoInstaller
    {
        [Inject] private BullPlayerPrefab bullPlayerPrefab;
        public override void InstallBindings()
        {
            Container.Bind<IPlayerBull>().To<ExecutorPlayerBull>().AsSingle().NonLazy();
            Container.BindFactory<PlayerBull, PlayerBull.Factory>().FromComponentInNewPrefab(bullPlayerPrefab.SetObject);
        }
    }
}

