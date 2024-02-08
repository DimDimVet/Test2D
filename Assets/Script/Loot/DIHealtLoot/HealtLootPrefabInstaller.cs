using Zenject;

namespace Loot
{
    public class HealtLootPrefabInstaller : MonoInstaller
    {
        [Inject] private HealtLootPrefab healtLootPrefab;
        public override void InstallBindings()
        {
            Container.Bind<IHealtLoot>().To<ExecutorHealtLoot>().AsSingle().NonLazy();
            Container.BindFactory<HealtLoot, HealtLoot.Factory>().FromComponentInNewPrefab(healtLootPrefab.SetObject);
        }
    }
}

