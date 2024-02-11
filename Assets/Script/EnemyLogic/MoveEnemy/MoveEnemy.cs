using Healt;
using RegistratorObject;
using UnityEngine;
using Zenject;

namespace EnemyLogic
{
    public class MoveEnemy : MonoBehaviour
    {
        public Transform[] JampPoint;
        [SerializeField] private MoveEnemySettings settings;
        [SerializeField] private Transform pointOutRay;
        private int thisHash;
        private float moveSpeed, jampSpeed, stopDistance,  gndDistance;
        private Rigidbody2D rbThisObject;
        private string tagGnd;
        private RaycastHit2D hit;
        private Vector3 scale, direction, directionJamp;
        private float isComJamp = 0, isComRight = 0;
        private bool isMoveTrigger;
        private Construction[] targets;
        private GameObject target;
        private TypeObject targetType;
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
            moveSpeed = settings.MoveSpeed;
            jampSpeed = settings.JampSpeed;
            stopDistance = settings.StopDistance;
            tagGnd = settings.TagGnd;
            gndDistance = settings.GndDistance;
        }
        private void GetRun()
        {
            if (!isRun)
            {
                rbThisObject = GetComponent<Rigidbody2D>();
                if (!(rbThisObject is Rigidbody2D)) { this.gameObject.AddComponent<Rigidbody2D>(); }
                isRun = true;
            }
        }
        void FixedUpdate()
        {
            if (isStopRun) { return; }
            if (!isRun) { GetRun(); return; }
            if (settings.IsUpDate) { SetSettings(); settings.IsUpDate = false; }
            Move();
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
                    if (targets[i].TypeObject == targetType && targets[i].Hash!=0) { target = targets[i].Object; return true; }
                }
            }
            return false;
        }
        private void Move()
        {
            SetTriggers();
            if (ScanGND())
            {
                isMoveTrigger = true;
                if (isComRight > 0)
                {
                    Flip(isComRight);
                    rbThisObject.velocity = transform.right * moveSpeed;
                }
                if (isComRight < 0)
                {
                    Flip(isComRight);
                    rbThisObject.velocity = -transform.right * moveSpeed;
                }
            }
            else
            {
                if (isComRight > 0 && isMoveTrigger)
                {
                    isMoveTrigger = false;
                    Flip(isComRight);
                    rbThisObject.velocity = transform.right * jampSpeed;
                }
                if (isComRight < 0 && isMoveTrigger)
                {
                    isMoveTrigger = false;
                    Flip(isComRight);
                    rbThisObject.velocity = -transform.right * jampSpeed;
                }
            }

            if (isComRight > 0 && isMoveTrigger && isComJamp > 0)
            {
                isMoveTrigger = false;
                Flip(isComRight);
                rbThisObject.velocity = new Vector2(1, 1) * jampSpeed;
                isComJamp = 0;
            }
            if (isComRight < 0 && isMoveTrigger && isComJamp > 0)
            {
                isMoveTrigger = false;
                Flip(isComRight);
                rbThisObject.velocity = -new Vector2(1, -1) * jampSpeed;
                isComJamp = 0;
            }
        }
        private void SetTriggers()
        {
            if (Target()) { direction = gameObject.transform.position - target.transform.position; }
            else { direction.x = 0;  }

            if (direction.x > 0 && direction.x > stopDistance) { isComRight = -1; }
            else if (direction.x < 0 && direction.x < -stopDistance) { isComRight = 1; }
            else { isComRight = 0; return; }

            if (isComJamp == 0)
            {
                for (int i = 0; i < JampPoint.Length; i++)
                {
                    directionJamp = gameObject.transform.position - JampPoint[i].transform.position;

                    if (Mathf.Abs(directionJamp.x) <= 1) { isComJamp = 1; }
                }
            }
            
        }
        private void Flip(float _scale)
        {
            scale = transform.localScale;
            scale.x = _scale;
            transform.localScale = scale;
        }
        private bool ScanGND()
        {
            hit = Physics2D.Raycast(pointOutRay.position, Vector2.down, gndDistance);

            if (hit.collider == null) { return false; }
            else if (hit.collider.gameObject.tag == tagGnd) { return true; }
            else { return false; }
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(pointOutRay.position, gndDistance);
        }

    }
}


