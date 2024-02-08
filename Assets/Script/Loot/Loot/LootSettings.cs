using UnityEngine;

namespace Loot
{
    [CreateAssetMenu(fileName = "LootSettings", menuName = "ScriptableObjects/LootSettings")]
    public class LootSettings : ScriptableObject
    {
        [Header("��������")]
        public float Healt = 1f;
        [Header("������� ����������"), Range(0, 1)]
        public float DiametrColl = 0.1f;
    }
}

