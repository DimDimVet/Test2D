using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BullInstaller : MonoInstaller
{
    [Inject] private BullPrefab bullPrefab;
    public override void InstallBindings()
    {
        Container.BindFactory<Bull, Bull.Factory>().FromComponentInNewPrefab(bullPrefab.SetObject);
    }
}
