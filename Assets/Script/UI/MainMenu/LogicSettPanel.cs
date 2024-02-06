using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LogicSettPanel : LogicPanel
    {
        [SerializeField] private ScreenSetting screenSetting;
        [SerializeField] private Dropdown screenDropdown;
        [SerializeField] private Slider muzSlider;
        [SerializeField] private Slider effectSlider;
        [SerializeField] private GameObject parentPanel;
        private Resolution[] resolutions, tempResolutions;
        private List<string> textScreen;
        private Resolution currentScreen;

        private float muzVol, effectVol;

        public override void SetSettings()
        {
            ScreenSet();
            AudioSet();
            SetEventButton();
        }
        void LateUpdate()
        {
            ChangeAudio();
        }
        private void ChangeAudio()
        {
            if (muzSlider.value != muzVol || effectSlider.value != effectVol)
            {
                muzVol = muzSlider.value;
                effectVol = effectSlider.value;
                SetNewAudio(muzVol, effectVol);
            }
        }
        public void SetEventButton()
        {
            screenDropdown.onValueChanged.AddListener(SetNewResolution);
        }
        private void ScreenSet()
        {
            //Screen
            if (screenSetting == null) { print($"Нет ScreenSetting"); return; }
            currentScreen = screenSetting.GetResolution();
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
        private void AudioSet()
        {
            //Audio
            AudioSetting.GetAudioParametr();
            muzVol = AudioSetting.MuzVol;
            effectVol = AudioSetting.EfectVol;

            muzSlider.value = muzVol;
            effectSlider.value = effectVol;
        }
        private void SetNewResolution(int indexDrop)
        {
            currentScreen.width = resolutions[indexDrop].width;
            currentScreen.height = resolutions[indexDrop].height;
            screenSetting.SetResolution(currentScreen);

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

        private void SetNewAudio(float newMuz, float newEffect)
        {
            AudioSetting.SetAudioParametr(newMuz, newEffect);
            //UpDateAudioParametr(); передать новые установки звука
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
        public override void ReturnPanel()
        {
            AudioClick();
            if (ThisPanel != null)
            { 
                ThisPanel.SetActive(false);
                parentPanel.SetActive(true);
            }
        }
    }
}

