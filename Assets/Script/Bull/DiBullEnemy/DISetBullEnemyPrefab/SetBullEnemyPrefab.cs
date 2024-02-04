using UnityEngine;
using Zenject;

namespace Bulls
{
    [CreateAssetMenu(fileName = "SetBullEnemyPrefab", menuName = "Installers/SetBullEnemyPrefab")]
    public class SetBullEnemyPrefab : ScriptableObjectInstaller<SetBullEnemyPrefab>
    {
        public BullEnemyPrefab BullEnemyPrefab;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BullEnemyPrefab>().FromInstance(BullEnemyPrefab).AsSingle();
        }
    }
}