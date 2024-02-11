using Zenject;

namespace Particle
{
    public class ParticleEndPrefabInstaller : MonoInstaller
    {
        [Inject] private ParticleEndPrefab particleEndPrefab;
        public override void InstallBindings()
        {
            Container.Bind<IParticleEnd>().To<ExecutorParticleEnd>().AsSingle().NonLazy();
            Container.BindFactory<ParticleEnd, ParticleEnd.Factory>().FromComponentInNewPrefab(particleEndPrefab.SetObject);
        }
    }
}

