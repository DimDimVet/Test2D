using UnityEngine;
using Zenject;

namespace Particle
{
    [CreateAssetMenu(fileName = "SetParticleEndPrefab", menuName = "Installers/SetParticleEndPrefab")]
    public class SetParticleEndPrefab : ScriptableObjectInstaller<SetParticleEndPrefab>
    {
        public ParticleEndPrefab ParticleEndPrefab;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ParticleEndPrefab>().FromInstance(ParticleEndPrefab).AsSingle();
        }
    }

}

