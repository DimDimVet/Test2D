using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class LogicButtonLvlPanel : MonoBehaviour
    {
        [SerializeField] private AudioSetting audioSetting;
        [SerializeField] private SceneSetting sceneSetting;
        [Header("Панели")]
        [SerializeField] private GameObject gndPanel;
        [SerializeField] private GameObject buttonLvlPanel;
        [SerializeField] private GameObject settingsPanel;
        [Header("Кнопка вернутся")]
        [SerializeField] private Button gameReternButton;
        [Header("Кнопка начать с начала")]
        [SerializeField] private Button rebootLvlButton;
        [Header("Кнопка настройка")]
        [SerializeField] private Button settingsButton;
        [Header("Кнопка в главное меню")]
        [SerializeField] private Button mainMenuButton;
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
            gameReternButton.onClick.AddListener(GameReternButton);
            rebootLvlButton.onClick.AddListener(RebootLvlButton);
            settingsButton.onClick.AddListener(SettingsButton);
            mainMenuButton.onClick.AddListener(MainMenuButton);
        }

        private void MainMenuButton()
        {
            AudioClick();
            Time.timeScale = 1f;
            SceneManager.LoadScene(sceneSetting.MenuSceneIndex);
        }

        private void SettingsButton()
        {
            buttonLvlPanel.SetActive(false);
            settingsPanel.SetActive(true);
        }

        private void RebootLvlButton()
        {
            ContinuationGame();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void GameReternButton()
        {
            ContinuationGame();
        }
        private void ContinuationGame()
        {
            AudioClick();
            Time.timeScale = 1f;
            buttonLvlPanel.SetActive(false);
            gndPanel.gameObject.SetActive(true);
        }
    }
}

