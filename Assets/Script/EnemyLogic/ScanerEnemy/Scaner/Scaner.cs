using RegistratorObject;
using UnityEngine;
using Zenject;

namespace EnemyLogic
{
    public class Scaner : MonoBehaviour
    {
        [SerializeField] private ScanerSetting settings;
        public Construction[] RezultScaner { get { return rezult; } }
        private TypeObject[] detectObject;
        private float distanceScaner;
        private RaycastHit2D[] hit;
        private Construction[] dataList, rezult;
        Masiv<Construction> massiv;
        private int tempHash;
        private bool isRun = false, isStopRun = false;

        private IRegistrator data;
        private IScanerExecutor scanerExecutor;
        [Inject]
        public void Init(IRegistrator r, IScanerExecutor s)
        {
            data = r;
            scanerExecutor = s;
        }
        void Start()
        {
            SetSettings();
        }
        private void SetSettings()
        {
            massiv = new Masiv<Construction>();
            detectObject = settings.DetectObject;
            distanceScaner = settings.DistanceScaner;
            detectObject = settings.DetectObject;
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
            if (settings.IsUpDate) { SetSettings(); settings.IsUpDate = false; }
            Detect();
        }
        private void Detect()
        {
            hit = Physics2D.CircleCastAll(gameObject.transform.position, distanceScaner, Vector2.zero);

            for (int i = 0; i < hit.Length; i++)
            {
                tempHash = hit[i].collider.gameObject.GetHashCode();
                if (tempHash != 0) { Select(tempHash); }
            }
        }
        private void Select(int hash)
        {
            if (scanerExecutor.ControlLoss()) { 
                massiv.Clean(rezult); }

            for (int y = 0; y < dataList.Length; y++)
            {
                if (dataList[y].Hash == hash)
                {
                    if (rezult != null)
                    {
                        if (massiv.Compare(rezult, dataList[y])) { return; }
                    }
                    else { LoadMassiv(dataList[y]); }
                }
            }
        }
        private void LoadMassiv(Construction data)
        {
            for (int i = 0; i < detectObject.Length; i++)
            {
                if (detectObject[i] == data.TypeObject)
                {
                    rezult = massiv.Creat(data, rezult);
                    scanerExecutor.SetRezultScaner(rezult);
                }
            }
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(gameObject.transform.position, distanceScaner);
        }
    }
}


