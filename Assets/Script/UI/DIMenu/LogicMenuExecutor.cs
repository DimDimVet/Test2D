using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public struct AudioData
    {
        public float MuzVol;
        public float EfectVol;
    }
    public class LogicMenuExecutor : ILogicMenu
    {
        public void SetAudioParametr(AudioData vol)
        {
            PlayerPrefs.SetFloat("CurrentMuzVol", vol.MuzVol);
            PlayerPrefs.SetFloat("CurrentEfectVol", vol.EfectVol);

        }
        public AudioData GetAudioParametr()
        {
            AudioData temp = new AudioData
            {
                MuzVol = PlayerPrefs.GetFloat("CurrentMuzVol"),
                EfectVol = PlayerPrefs.GetFloat("CurrentEfectVol")
            };
            return temp;
        }
        public void ReturnMainMenu(int menuSceneIndex)
        {
            SceneManager.LoadScene(menuSceneIndex);
        }
        public void SetResolution(Resolution currentScreen)
        {
            PlayerPrefs.SetInt("CurrentWidth", currentScreen.width);
            PlayerPrefs.SetInt("CurrentHeight", currentScreen.height);
        }
        public Resolution GetResolution()
        {
            Resolution temp = new Resolution();
            temp.width = PlayerPrefs.GetInt("CurrentWidth");
            temp.height = PlayerPrefs.GetInt("CurrentHeight");
            return temp;
        }
    }
}

