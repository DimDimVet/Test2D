using UnityEngine;
using Zenject;

namespace Input
{
    public class MovePlayer : MonoBehaviour
    {
        [SerializeField] private MoveSettings settings;
        [SerializeField] private Transform pointOutRay;
        private float moveSpeed, jampSpeed, gndDistance;
        private Rigidbody2D rbThisObject;
        private string tagGnd;
        private RaycastHit2D hit;
        private Vector3 scale;
        private bool isMoveTrigger, isFlipTrigger;
        private bool isRun = false, isStopRun = false;

        private IInput inputData;
        [Inject]
        public void Init(IInput x)
        {
            inputData = x;
        }
        void Start()
        {
            inputData.Enable();
            SetSettings();
        }
        private void SetSettings()
        {
            moveSpeed = settings.MoveSpeed;
            jampSpeed = settings.JampSpeed;
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
        void Update()
        {
            if (isStopRun) { return; }
            if (!isRun) { GetRun(); return; }
            if (settings.IsUpDate) { SetSettings(); settings.IsUpDate = false; }
            Move();
        }
        private void Move()
        {
            if (ScanGND())
            {
                isMoveTrigger = true;
                if (inputData.Updata().Jamp > 0)
                {
                    rbThisObject.AddForce(transform.up * jampSpeed, ForceMode2D.Impulse);
                }
                else
                {
                    if (inputData.Updata().Move.x > 0 )
                    {
                        if (isFlipTrigger == true && inputData.Updata().Move.x > 0) { Flip(); }
                        rbThisObject.velocity = transform.right * moveSpeed;
                    }
                    if (inputData.Updata().Move.x < 0 )
                    {
                        if (isFlipTrigger == false && inputData.Updata().Move.x < 0) { Flip(); }
                        rbThisObject.velocity = -transform.right * moveSpeed;
                    }
                }

            }
            else
            {
                if (inputData.Updata().Move.x > 0 && isMoveTrigger)
                {
                    isMoveTrigger = false;
                    if (isFlipTrigger == true && inputData.Updata().Move.x > 0) { Flip(); }
                    rbThisObject.AddForce(transform.right * moveSpeed / 2, ForceMode2D.Impulse);
                }
                if (inputData.Updata().Move.x < 0 && isMoveTrigger)
                {
                    isMoveTrigger = false;
                    if (isFlipTrigger == false && inputData.Updata().Move.x < 0) { Flip(); }

                    rbThisObject.AddForce(-transform.right * moveSpeed / 2, ForceMode2D.Impulse);
                }

            }
        }
        private void Flip()
        {
            isFlipTrigger = !isFlipTrigger;
            scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

            //rbThisObject.velocity.magnitude
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

