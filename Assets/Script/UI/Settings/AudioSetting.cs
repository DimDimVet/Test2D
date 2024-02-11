using System;
using UnityEngine;

namespace UI
{
    [CreateAssetMenu(fileName = "AudioSetting", menuName = "ScriptableObjects/AudioSetting")]
    public class AudioSetting : ScriptableObject
    {

        [Header("������� ������"), Range(0, 1)]
        public float MuzVol = 0.5f;
        [Header("������� ��������"), Range(0, 1)]
        public float EfectVol = 0.5f;

        [Header("�������� ���� - ������")]
        public AudioClip AudioClipButton;

        [Header("�������� ���� - ���")]
        public AudioClip AudioClipGnd;

    }
}

