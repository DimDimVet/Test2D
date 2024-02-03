using Zenject;

namespace Input
{
    public class InputPlayerInstaller : MonoInstaller
    {
        //[Inject] private BullPrefab bullPrefab;
        public override void InstallBindings()
        {
            Container.Bind<IInput>().To<InputPlayer>().AsSingle().NonLazy();
            //Container.BindFactory<Bull, Bull.Factory>().FromComponentInNewPrefab(bullPrefab.SetObject);
        }
    }
}
