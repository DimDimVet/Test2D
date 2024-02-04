using RegistratorObject;
using UnityEngine;

namespace EnemyLogic
{

    public class ScanerEnemy : MonoBehaviour
    {
        [SerializeField] private ScanerSetting settings;
        private TypeObject[] detectObject;
        private string[] nameTag;
        private float distanceScaner;
        private RaycastHit2D[] hit;
        private Construction[] baseObject, tempData;
        private Construction tempConstructor;
        private int tempHash;
        private Masiv<Construction> massiv;
        private bool isRun = false, isStopRun = false;

        //private IInput inputData;
        //[Inject]
        //public void Init(IInput x)
        //{
        //    inputData = x;
        //}
        void Start()
        {
            SetSettings();
        }
        private void SetSettings()
        {
            massiv = new Masiv<Construction>();
            detectObject = settings.DetectObject;
            distanceScaner = settings.DistanceScaner;

        }
        private void GetRun()
        {
            if (!isRun)
            {
                if (baseObject == null) { baseObject = BaseObject.GetAll(); isRun = true; return; }
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

                for (int j = 0; j < baseObject.Length; j++)
                {
                    if (baseObject[j].Hash == tempHash) { CreatTempData(baseObject[j]); }

                }
            }
        }
        private void CreatTempData(Construction tempConstructor)
        {
            if (tempData == null) { tempData = new Construction[] { tempConstructor }; for (int i = 0; i < tempData.Length; i++) { Debug.Log(tempData[i].Hash); } }
            if (massiv.Compare(tempData, tempConstructor))
            {
                return;
            }
            else { tempData = massiv.Creat(tempConstructor, tempData); for (int i = 0; i < tempData.Length; i++) { Debug.Log(tempData[i].Hash); } }
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(gameObject.transform.position, distanceScaner);
        }

    }
}


