using UnityEngine;

namespace UI
{
    public interface ILogicMenu
    {
        AudioData GetAudioParametr();
        Resolution GetResolution();
        void ReturnMainMenu(int menuSceneIndex);
        void SetAudioParametr(AudioData vol);
        void SetResolution(Resolution currentScreen);
    }
}
