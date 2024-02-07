using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class LogicButtonMainMenu : MonoBehaviour
    {
        [SerializeField] private AudioSetting audioSetting;
        [SerializeField] private SceneSetting sceneSetting;
        [Header("Указать ButtonPanel")]
        [SerializeField] private GameObject buttonPanel;
        [Header("Кнопка Игра")]
        [SerializeField] private Button gameButton;
        private int gameSceneIndex;
        [Header("Кнопка Настройка")]
        [SerializeField] private Button settButton;
        [SerializeField] private GameObject settPanel;
        [Header("Кнопка Выход")]
        [SerializeField] private Button exitButton;
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
            if (sceneSetting != null & gameButton != null & settButton != null &
            exitButton != null)
            {
                gameSceneIndex = sceneSetting.GameSceneIndex;
                vol = new AudioData();
                SetEventButton();
                SetPanel();
            }
            else { return; }

            if (audioSetting != null)
            {
                audioSourceButton = gameObject.AddComponent<AudioSource>();
                audioSourceButton.clip = audioSetting.AudioClipButton;
                vol = logicMenu.GetAudioParametr();
                audioSourceButton.volume = vol.EfectVol;
            }
        }
        public void AudioClick()
        {
            audioSourceButton.Play();
        }
        private void SetEventButton()
        {
            gameButton.onClick.AddListener(StartGame);
            settButton.onClick.AddListener(SettGame);
            exitButton.onClick.AddListener(ExitGame);
        }
        private void SetPanel()
        {
            settPanel.SetActive(false);
        }
        private void StartGame()
        {
            AudioClick();
            SceneManager.LoadScene(gameSceneIndex);
        }
        private void SettGame()
        {
            AudioClick();
            settPanel.SetActive(true);
            buttonPanel.SetActive(false); ;
        }
        private void ExitGame()
        {
            AudioClick();
            Application.Quit();
        }
    }
}

