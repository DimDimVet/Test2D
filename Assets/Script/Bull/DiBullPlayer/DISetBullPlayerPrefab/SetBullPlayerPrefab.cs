using UnityEngine;
using Zenject;

namespace Bulls
{
    [CreateAssetMenu(fileName = "SetBullPlayerPrefab", menuName = "Installers/SetBullPlayerPrefab")]
    public class SetBullPlayerPrefab : ScriptableObjectInstaller<SetBullPlayerPrefab>
    {
        public BullPlayerPrefab BullPlayerPrefab;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BullPlayerPrefab>().FromInstance(BullPlayerPrefab).AsSingle();
        }
    }
}

