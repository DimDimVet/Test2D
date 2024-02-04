using Zenject;

namespace Bulls
{
    public class BullEnemyPrefabInstaller : MonoInstaller
    {
        [Inject] private BullEnemyPrefab bullEnemyPrefab;
        public override void InstallBindings()
        {
            Container.Bind<IEnemyBull>().To<ExecutorEnemyBull>().AsSingle().NonLazy();
            Container.BindFactory<EnemyBull, EnemyBull.Factory>().FromComponentInNewPrefab(bullEnemyPrefab.SetObject);
        }
    }
}