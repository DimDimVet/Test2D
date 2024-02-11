using Healt;
using RegistratorObject;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace UI
{
    public class LogicSelectScene : MonoBehaviour
    {
        [SerializeField] private SceneSetting sceneSetting;
        
        private Construction[] dataList,rezultEnemy, rezultPlayer;
        private int countEnemy;
        private Masiv<Construction> massiv;
        private bool isRun = false, isStopRun = false;

        private IRegistrator data;
        private IHealt healtExecutor;
        [Inject]
        public void Init(IHealt h, IRegistrator r)
        {
            data = r;
            healtExecutor = h;
        }
        private void OnEnable()
        {
            isStopRun = false;
            healtExecutor.OnIsDead += IsDead;
        }
        void Start()
        {
            SetSettings();
        }
        private void SetSettings()
        {
            massiv = new Masiv<Construction>();
        }
        private void GetRun()
        {
            if (!isRun)
            {
                dataList = data.SetList();
                if (dataList != null) { isRun = true; return; }
                isRun = false;
            }
        }
        void Update()
        {
            if (isStopRun) { return; }
            if (!isRun) { GetRun(); }
        }
        private void IsDead(int getHash, bool isDead)
        {
            CountEnemy(getHash);
            KillPlayer(getHash);
        }
        private void FindEnemy()
        {
            if (dataList == null) { return; }

            for (int i = 0; i < dataList.Length; i++)
            {
                if (dataList[i].TypeObject == TypeObject.Enemy)
                { rezultEnemy = massiv.Creat(dataList[i], rezultEnemy); }
            }
            countEnemy = rezultEnemy.Length;
        }
        private void FindPlayer()
        {
            if (dataList == null) { return; }

            for (int i = 0; i < dataList.Length; i++)
            {
                if (dataList[i].TypeObject == TypeObject.Player)
                { rezultPlayer = massiv.Creat(dataList[i], rezultPlayer); }
            }
        }
        private void KillPlayer(int getHash)
        {
            if (rezultPlayer == null) { FindPlayer(); }
            for (int i = 0; i < rezultPlayer.Length; i++)
            {
                if (rezultPlayer[i].Hash == getHash)
                {
                    SceneManager.LoadScene(sceneSetting.OverSceneIndex);
                }
            }
        }
        private void CountEnemy(int getHash)
        {
            if (rezultEnemy == null) { FindEnemy(); }

            for (int i = 0; i < rezultEnemy.Length; i++)
            {
                if (rezultEnemy[i].Hash == getHash)
                {
                    countEnemy--;
                    if (countEnemy <= 0) { SceneManager.LoadScene(sceneSetting.VictorySceneIndex); }
                }
            }
        }
    }
}

