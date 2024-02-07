using UnityEngine;

namespace UI
{
    [CreateAssetMenu(fileName = "ScreenSetting", menuName = "ScriptableObjects/ScreenSetting")]
    public class ScreenSetting : ScriptableObject
    {
        [Header("Мин ширина(width)")]
        public int MinWidth = 1280;
        [Header("Мин высота(height)")]
        public int MinHeight = 1024;
    }
}

