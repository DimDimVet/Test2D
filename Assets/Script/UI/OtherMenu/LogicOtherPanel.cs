using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class LogicOtherPanel : MonoBehaviour
    {
        [SerializeField] private SceneSetting sceneSetting;
        [SerializeField] private AudioSetting audioSetting;
        [SerializeField] private TextSetting textSetting;
        [Header("Кнопка Назад")]
        [SerializeField] private Button returnButton;
        [SerializeField] private GameObject thisPanel;
        [SerializeField] private Text text;
        private int mainMenuIndex;
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
            if (audioSetting != null)
            {
                vol = new AudioData();
                vol = logicMenu.GetAudioParametr();

                audioSourceButton = gameObject.AddComponent<AudioSource>();
                audioSourceGnd = gameObject.AddComponent<AudioSource>();

                audioSourceButton.clip = audioSetting.AudioClipButton;
                audioSourceButton.volume = vol.EfectVol;
                audioSourceGnd.clip = audioSetting.AudioClipGnd;
                audioSourceGnd.volume = vol.MuzVol;
                audioSourceGnd.Play();
            }
            text.text = textSetting.BaseTextScene;
            mainMenuIndex = sceneSetting.MenuSceneIndex;
        }
        public void SetEventButton()
        {
            returnButton.onClick.AddListener(ReturnPanel);
        }
        public void AudioClick()
        {
            audioSourceButton.Play();
        }
        public void ReturnPanel()
        {
            AudioClick();
            if (thisPanel != null)
            {
                thisPanel.SetActive(false);
                SceneManager.LoadScene(mainMenuIndex);
            }
        }
    }
}


