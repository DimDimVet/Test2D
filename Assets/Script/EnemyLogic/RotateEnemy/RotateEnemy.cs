using Healt;
using RegistratorObject;
using UnityEngine;
using Zenject;

namespace EnemyLogic
{
    public class RotateEnemy : MonoBehaviour
    {
        [SerializeField] private RotatseSetting settings;
        [SerializeField] private GameObject childGameObject;
        private Construction[] targets;
        private int thisHash;
        private GameObject target;
        private TypeObject targetType;
        private float anglePlus, angleMinus, angle;
        private Vector2 direction;
        private Vector3 scale;
        private bool isRun = false, isStopRun = false;

        private IHealt healtExecutor;
        private IScanerExecutor scanerExecutor;
        [Inject]
        public void Init(IScanerExecutor s, IHealt h)
        {
            scanerExecutor = s;
            healtExecutor = h;
        }
        private void OnEnable()
        {
            healtExecutor.OnIsDead += IsDead;
        }
        void Start()
        {
            SetSettings();
        }
        private void SetSettings()
        {
            thisHash = gameObject.GetHashCode();
            targetType = settings.TypeObject;
            anglePlus = settings.AnglePlus;
            angleMinus = settings.AngleMinus;
        }
        private void GetRun()
        {
            if (!isRun)
            {
                isRun = true;
            }
        }
        void Update()
        {
            if (isStopRun) { return; }
            if (!isRun) { GetRun(); }
            if (settings.IsUpDate) { SetSettings(); settings.IsUpDate = false; }
            Rotate();
        }
        private void IsDead(int getHash, bool isDead)
        {
            if (thisHash == getHash) { isStopRun = isDead; }
        }
        private bool Target()
        {
            if (targets == null) { targets = scanerExecutor.GetRezultScaner(thisHash); return false; }
            else
            {
                for (int i = 0; i < targets.Length; i++)
                {
                    if (targets[i].TypeObject == targetType && targets[i].Hash != 0) { target = targets[i].Object; return true; }
                }
            }
            return false;
        }
        private void Rotate()
        {
            scale = transform.localScale;

            if (Target()) { direction = target.transform.position - gameObject.transform.position; Flip(direction); }
            else { return; }

            angle = Vector2.SignedAngle(Vector2.right, direction);

            if (scale.x < 0)
            {
                if (angle >= 90 && angle <= 180) { angle = 180 - angle; }
                if (angle <= -90 && angle >= -180) { angle = -180 - angle; }

                if (angle <= angleMinus) { angle = angleMinus; }
                if (angle >= anglePlus) { angle = anglePlus; }
                childGameObject.transform.eulerAngles = new Vector3(0, 0, -angle);

            }
            if (scale.x > 0)
            {
                if (angle >= anglePlus) { angle = anglePlus; }
                if (angle <= angleMinus) { angle = angleMinus; }
                childGameObject.transform.eulerAngles = new Vector3(0, 0, angle);
            }
        }
        private void Flip(Vector2 direction)
        {
            scale = transform.localScale;
            if (direction.x > 0) { scale.x = 1; }
            else { scale.x = -1; }
            transform.localScale = scale;
        }
    }
}


