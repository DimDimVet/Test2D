using Healt;
using UnityEngine;

namespace RegistratorObject
{
    public struct Construction : IConstruction
    {
        public int Hash { get; set; }
        public TypeObject TypeObject { get; set; }

        public GameObject Object;
        public int ParentHashObject;
        public bool isDead;
        public HealtPlayer HealtPlayer;
        public HealtEnemy HealtEnemy;
    }
}

