using Zenject;

namespace Pools
{
    public class ParticleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IParticlePool>().To<ExecutorParticle>().AsSingle().NonLazy();
        }
    }
}

