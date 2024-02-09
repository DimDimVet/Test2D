using UnityEngine;

namespace Loot
{
    [CreateAssetMenu(fileName = "LootSettings", menuName = "ScriptableObjects/LootSettings")]
    public class LootSettings : ScriptableObject
    {
        [Header("Здоровье")]
        public int Healt = 1;
        [Header("Диаметр коллайдера"), Range(0, 1)]
        public float DiametrColl = 0.1f;
    }
}

