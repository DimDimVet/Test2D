using Bulls;
using Pools;
using RegistratorObject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Loot
{
    public class HealtLoot : Loot
    {
        //private IEnemyBullPool poolBull;
        //private IEnemyBull enemyBull;
        //[Inject]
        //public void Init(IEnemyBullPool _poolBull, IEnemyBull _enemyBull)
        //{
        //    poolBull = _poolBull;
        //    enemyBull = _enemyBull;
        //}
        public override void Executor(Construction player)
        {
        }
        public override void ReternLoot()
        {
            //poolBull.ReternObject(this.gameObject.GetHashCode());
        }
        public class Factory : PlaceholderFactory<HealtLoot>
        {
        }
    }
}

