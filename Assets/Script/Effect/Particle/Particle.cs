using UnityEngine;

namespace Particle
{
    public class Particle : MonoBehaviour
    {
        private ParticleSystem particle;

        void Start()
        {
            SetSettings();
        }
        private void SetSettings()
        {
            if (particle == null) { particle = GetComponent<ParticleSystem>(); }

        }
    }
}


