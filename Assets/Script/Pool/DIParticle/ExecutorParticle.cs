using Particle;
using UnityEngine;
using Zenject;

namespace Pools
{
    public class ExecutorParticle : IParticlePool
    {
        private Pool pool;
        [Inject]
        private ParticleEnd.Factory particleEndFactory;

        private void AddPull(Transform containerTransform)
        {
            ParticleEnd rezult = particleEndFactory.Create();
            pool = new Pool(rezult.gameObject, containerTransform, true);
        }

        public GameObject GetObject(float direction, Transform containerTransform)
        {
            if (pool == null) { AddPull(containerTransform); }
            GameObject tempGameObject = pool.GetObjectFabric(containerTransform);

            if (tempGameObject != null) { return tempGameObject; }
            else
            {
                ParticleEnd rezult = particleEndFactory.Create();
                pool.NewObjectQueue(rezult.gameObject);
                return pool.GetObjectFabric(containerTransform);
            }
        }

        public void ReternObject(int _hash)
        {
            pool.ReternObject(_hash);
        }
    }
}

