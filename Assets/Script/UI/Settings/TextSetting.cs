using UnityEngine;

namespace UI
{
    [CreateAssetMenu(fileName = "TextSetting", menuName = "ScriptableObjects/TextSetting")]
    public class TextSetting : ScriptableObject
    {
        [Header("Текст для сцены")]
        public string BaseTextScene = $"";
    }
}

