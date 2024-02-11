using UnityEngine;

namespace Traps
{
    [CreateAssetMenu(fileName = "TrapSettings", menuName = "ScriptableObjects/TrapSettings")]
    public class TrapSettings : ScriptableObject
    {
        [Header("Дамаг")]
        public int Damage = 1;
        [Header("Диаметр коллайдера"), Range(0, 10)]
        public float DiametrColl = 0.1f;
    }

}

