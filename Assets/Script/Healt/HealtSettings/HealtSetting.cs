using UnityEngine;

namespace Healt
{
    [CreateAssetMenu(fileName = "HealtSettings", menuName = "ScriptableObjects/HealtSettings")]
    public class HealtSetting : ScriptableObject
    {
        [Header("������� ��������")]
        public int HealtCount = 1000;
        [Header("��������� �������")]
        public int CostObject = 1;
    }
}

