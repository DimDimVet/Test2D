using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class LogicButtonMainMenu : LogicPanel
    {
        [SerializeField] private SceneSetting sceneSetting;
        [Header("������� ButtonPanel")]
        [SerializeField] private GameObject buttonPanel;
        [Header("������ ����")]
        [SerializeField] private Button gameButton;
        [Header("������� ������ ����� ����")]
        private int gameSceneIndex;
        [Header("������ ���������")]
        [SerializeField] private Button settButton;
        [SerializeField] private GameObject settPanel;
        [Header("������ �����")]
        [SerializeField] private Button exitButton;
        private AudioSource audioSourceGnd;

        public override void SetSettings()
        {
            if (sceneSetting != null & gameButton != null & settButton != null &
            exitButton != null)
            {
                gameSceneIndex = sceneSetting.GameSceneIndex;
                SetEventButton();
                SetPanel();
            }
            else { return; }

            if (AudioSetting != null)
            {
                //audioSourceButton = gameObject.AddComponent<AudioSource>();
                audioSourceGnd = gameObject.AddComponent<AudioSource>();
                //audioSourceButton.clip = AudioSetting.AudioClipButton;
                audioSourceGnd.clip = AudioSetting.AudioClipGnd;
                //audioSourceButton.volume = (AudioSetting.EfectVol);
                audioSourceGnd.volume = (AudioSetting.MuzVol);
            }
            audioSourceGnd.Play();
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

