using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LogicPanel : MonoBehaviour
    {
        public AudioSetting AudioSetting { get { return audioSetting; } set { audioSetting = value; } }
        public GameObject ThisPanel { get { return thisPanel; } set { thisPanel = value; } }
        [SerializeField] private AudioSetting audioSetting;
        [Header("Кнопка Назад")]
        [SerializeField] private Button returnButton;
        [SerializeField] private GameObject thisPanel;
        private AudioSource audioSourceButton;
        private bool isRun = false;

        void Start()
        {
            SetSettings();
            SetEventReturnButton();
        }
        public virtual void SetSettings()
        {
        }
        private void GetRun()
        {
            if (!isRun)
            {
                if (AudioSetting != null)
                {
                    audioSourceButton = gameObject.AddComponent<AudioSource>();
                    audioSourceButton.clip = AudioSetting.AudioClipButton;
                    audioSourceButton.volume = (AudioSetting.EfectVol);
                    isRun = true;
                }
                else { isRun = false; }
            }
        }
        void Update()
        {
            if (!isRun) { GetRun(); }
        }
        private void SetEventReturnButton()
        {
            returnButton.onClick.AddListener(ReturnPanel);
        }
        public void AudioClick()
        {
            audioSourceButton.Play();
        }
        public virtual void ReturnPanel()
        {
            AudioClick();
            if (ThisPanel != null) { ThisPanel.SetActive(false); }
        }
    }
}

