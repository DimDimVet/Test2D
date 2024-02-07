using UnityEngine;

namespace UI
{
    [CreateAssetMenu(fileName = "TextSetting", menuName = "ScriptableObjects/TextSetting")]
    public class TextSetting : ScriptableObject
    {
        [Header("����� ��� �����")]
        public string BaseTextScene = $"";
    }
}

