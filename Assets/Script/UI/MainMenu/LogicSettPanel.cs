using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class LogicSettPanel : MonoBehaviour
    {
        [SerializeField] private AudioSetting audioSetting;
        [SerializeField] private ScreenSetting screenSetting;
        [SerializeField] private Dropdown screenDropdown;
        [SerializeField] private Slider muzSlider;
        [SerializeField] private Slider effectSlider;
        [SerializeField] private GameObject parentPanel;
        [Header("Кнопка Назад")]
        [SerializeField] private Button returnButton;
        [SerializeField] private GameObject thisPanel;
        private Resolution[] resolutions, tempResolutions;
        private List<string> textScreen;
        private Resolution currentScreen;
        private AudioData vol;
        private AudioSource audioSourceButton, audioSourceGnd;

        private ILogicMenu logicMenu;
        [Inject]
        public void Init(ILogicMenu m)
        {
            logicMenu = m;
        }
        void Start()
        {
            SetSettings();
            SetEventButton();
        }
        public void SetSettings()
        {
            audioSourceButton = GetComponent<AudioSource>();
            audioSourceGnd = gameObject.AddComponent<AudioSource>();
            if (audioSourceButton == null) { audioSourceButton = gameObject.AddComponent<AudioSource>(); }

            audioSourceButton.clip = audioSetting.AudioClipButton;
            audioSourceGnd.clip = audioSetting.AudioClipGnd;
            audioSourceGnd.Play();

            ScreenSet();
            AudioSet();
        }
        public void SetEventButton()
        {
            screenDropdown.onValueChanged.AddListener(SetNewResolution);
            returnButton.onClick.AddListener(ReturnPanel);
        }
        void Update()
        {
            ChangeAudio();
        }
        private void ChangeAudio()
        {
            if (muzSlider.value != vol.MuzVol || effectSlider.value != vol.EfectVol)
            {
                vol.MuzVol = muzSlider.value;
                vol.EfectVol = effectSlider.value;
                logicMenu.SetAudioParametr(vol);
                AudioSet();
            }
        }
        private void AudioSet()
        {
            vol = new AudioData();
            vol = logicMenu.GetAudioParametr();
            
            audioSourceButton.volume = vol.EfectVol;
            if (audioSourceGnd != null) { audioSourceGnd.volume = vol.MuzVol; }

            muzSlider.value = vol.MuzVol;
            effectSlider.value = vol.EfectVol;
        }
        public void AudioClick()
        {
            audioSourceButton.Play();
        }
        private void ScreenSet()
        {
            //Screen
            if (screenSetting == null) { print($"Нет ScreenSetting"); return; }
            currentScreen = logicMenu.GetResolution();
            SetCurrentResolution(currentScreen);

            textScreen = new List<string>();
            tempResolutions = Screen.resolutions;
            screenDropdown.ClearOptions();

            for (int i = 0; i < tempResolutions.Length; i++)
            {
                if (tempResolutions[i].width >= screenSetting.MinWidth & tempResolutions[i].height >= screenSetting.MinHeight)
                {
                    resolutions = CreatResolution(tempResolutions[i], resolutions);
                    textScreen.Add($"{tempResolutions[i].width}x{tempResolutions[i].height}");
                }
            }
            screenDropdown.AddOptions(textScreen);

            //покажем текущее значение в дропе
            for (int i = 0; i < resolutions.Length; i++)
            {
                if (resolutions[i].width == currentScreen.width & resolutions[i].height == currentScreen.height)
                {
                    screenDropdown.value = i;
                }
            }
        }
        
        private void SetNewResolution(int indexDrop)
        {
            currentScreen.width = resolutions[indexDrop].width;
            currentScreen.height = resolutions[indexDrop].height;
            logicMenu.SetResolution(currentScreen);

            SetCurrentResolution(currentScreen);
        }
        private void SetCurrentResolution(Resolution _currentScreen)
        {
            if (_currentScreen.width == 0 & _currentScreen.height == 0)
            {
                _currentScreen.width = screenSetting.MinWidth;
                _currentScreen.height = screenSetting.MinHeight;
            }

            bool fullScreen = true;
            Screen.SetResolution(_currentScreen.width, _currentScreen.height, fullScreen);
        }

        private Resolution[] CreatResolution(Resolution intObject, Resolution[] massivObject)
        {
            if (massivObject != null)
            {
                int newLength = massivObject.Length + 1;
                Array.Resize(ref massivObject, newLength);
                massivObject[newLength - 1] = intObject;
                return massivObject;
            }
            else
            {
                massivObject = new Resolution[] { intObject };
                return massivObject;
            }
        }
        public void ReturnPanel()
        {
            AudioClick();
            if (thisPanel != null)
            { 
                thisPanel.SetActive(false);
                parentPanel.SetActive(true);
            }
        }
    }
}

