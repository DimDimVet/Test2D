using Input;
using Zenject;

public class InputPlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IInput>().To<InputPlayer>().AsSingle().NonLazy();
    }
}