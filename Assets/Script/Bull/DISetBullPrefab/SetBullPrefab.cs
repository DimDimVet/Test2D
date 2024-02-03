using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
[CreateAssetMenu(fileName = "SetBullPrefab", menuName = "Installers/SetBullPrefab")]
public class SetBullPrefab : ScriptableObjectInstaller<SetBullPrefab>
{
    public BullPrefab BullPrefab;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<BullPrefab>().FromInstance(BullPrefab).AsSingle();
    }
}
