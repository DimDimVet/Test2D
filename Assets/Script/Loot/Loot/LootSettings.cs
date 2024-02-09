using UnityEngine;

namespace Loot
{
    [CreateAssetMenu(fileName = "LootSettings", menuName = "ScriptableObjects/LootSettings")]
    public class LootSettings : ScriptableObject
    {
        [Header("��������")]
        public int Healt = 1;
        [Header("������� ����������"), Range(0, 1)]
        public float DiametrColl = 0.1f;
    }
}

