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

        public void SetAudioParametr(float muzVol, float efectVol)
        {
            PlayerPrefs.SetFloat("CurrentMuzVol", muzVol);
            PlayerPrefs.SetFloat("CurrentEfectVol", efectVol);
            MuzVol = muzVol;
            EfectVol = efectVol;
        }
        public void GetAudioParametr()
        {
            MuzVol = PlayerPrefs.GetFloat("CurrentMuzVol");
            EfectVol = PlayerPrefs.GetFloat("CurrentEfectVol");
        }
    }
}

