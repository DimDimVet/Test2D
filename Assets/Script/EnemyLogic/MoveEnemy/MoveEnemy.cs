using UnityEngine;

namespace EnemyLogic
{
    public class MoveEnemy : MonoBehaviour
    {
        public GameObject target;
        public Transform[] JampPoint;
        [SerializeField] private MoveEnemySettings settings;
        [SerializeField] private Transform pointOutRay;
        private float moveSpeed, jampSpeed, stopDistance, gndDistance;
        private Rigidbody2D rbThisObject;
        private string tagGnd;
        private RaycastHit2D hit;
        private Vector3 scale, direction, directionJamp;
        [SerializeField] private float isComJamp = 0, isComRight = 0;
        private bool isMoveTrigger;
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

        private void Move()
        {
            SetTriggers();
            if (ScanGND())
            {
                isMoveTrigger = true;
                if (isComJamp > 0)
                {
                    rbThisObject.velocity = transform.up * jampSpeed;
                }
                else
                {
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
            }
            if (isComRight < 0 && isMoveTrigger && isComJamp > 0)
            {
                isMoveTrigger = false;
                Flip(isComRight);
                rbThisObject.velocity = -new Vector2(1, -1) * jampSpeed;
            }

        }
        private void SetTriggers()
        {
            direction = gameObject.transform.position - target.transform.position;

            if (direction.x > 0 && direction.x > stopDistance) { isComRight = -1; }
            else if (direction.x < 0 && direction.x < -stopDistance) { isComRight = 1; }
            else { isComRight = 0; return; }

            for (int i = 0; i < JampPoint.Length; i++)
            {
                directionJamp = gameObject.transform.position - JampPoint[i].transform.position;
                if (Mathf.Abs(directionJamp.x) <= 1) { isComJamp = 1; }
                else { isComJamp = 0; }
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

