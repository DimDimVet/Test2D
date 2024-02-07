using UnityEngine;

namespace UI
{
    [CreateAssetMenu(fileName = "ScreenSetting", menuName = "ScriptableObjects/ScreenSetting")]
    public class ScreenSetting : ScriptableObject
    {
        [Header("��� ������(width)")]
        public int MinWidth = 1280;
        [Header("��� ������(height)")]
        public int MinHeight = 1024;
    }
}

