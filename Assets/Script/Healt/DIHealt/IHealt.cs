using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Healt
{
    public interface IHealt
    {
        public Action<int, int> OnGetDamage { get; set; }

        public void SetDamage(int getHash, int damage);
    }
}

