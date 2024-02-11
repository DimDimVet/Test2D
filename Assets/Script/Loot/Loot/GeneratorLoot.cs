using Healt;
using Pools;
using UnityEngine;
using Zenject;

namespace Loot
{
    public class GeneratorLoot : MonoBehaviour
    {
        public Transform ContainerHealtLoot;
        private int thisHash;
        private bool isRun = false, isStopRun = false;

        private ILootPool lootPool;
        private IHealt healtExecutor;
        [Inject]
        public void Init(IHealt _healtExecutor, ILootPool _lootPool)
        {
            healtExecutor = _healtExecutor;
            lootPool= _lootPool;
        }
        private void OnEnable()
        {
            isStopRun = false;
            healtExecutor.OnIsDead += IsDead;
        }
        void Start()
        {
            SetSettings();
        }
        private void SetSettings()
        {
            thisHash = gameObject.GetHashCode();
        }
        private void GetRun()
        {
            if (!isRun)
            {
                isRun=true;
            }
        }
        void Update()
        {
            if (isStopRun) { return; }
            if (!isRun) { GetRun(); }
        }
        private void IsDead(int getHash, bool isDead)
        {
            if (thisHash == getHash)
            {
                lootPool.GetObject(1, ContainerHealtLoot);
                isStopRun = isDead;
            }
        }

    }
}

