using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class LogicGndPanel : MonoBehaviour
    {
        [SerializeField] private AudioSetting audioSetting;
        [Header("Кнопка пауза")]
        [SerializeField] private Button menuButton;
        [SerializeField] private GameObject gndPanel;
        [SerializeField] private GameObject buttonLvlPanel;
        private AudioSource audioSourceGnd;
        private AudioSource audioSourceButton;
        private AudioData vol;

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

            vol = logicMenu.GetAudioParametr();
            audioSourceButton.volume = vol.EfectVol;
            audioSourceGnd.volume = vol.MuzVol;

            audioSourceButton.clip = audioSetting.AudioClipButton;
            audioSourceGnd.clip = audioSetting.AudioClipGnd;
            audioSourceGnd.Play();
        }
        public void AudioClick()
        {
            audioSourceButton.Play();
        }
        private void SetEventButton()
        {
            menuButton.onClick.AddListener(StartButtonPanel);
        }
        private void StartButtonPanel()
        {
            gndPanel.SetActive(false);
            buttonLvlPanel.SetActive(true);
            AudioClick();
            Time.timeScale = 0f;
        }
    }
}

