using Healt;
using UnityEngine;
using Zenject;

namespace Dead
{
    public class DeadEnemy : MonoBehaviour
    {
        [SerializeField] private float killTime;

        [Header("Скорость прыжка"), Range(0, 20)]
        [SerializeField] private float jampSpeed;

        private Rigidbody2D rigidBody;
        private Collider2D colliderObject;
        private float defaultTime;
        private int thisHash;
        private bool isMoveTrigger = false;
        private bool isDead = false, isStopRun = false;

        private IHealt healtExecutor;
        [Inject]
        public void Init(IHealt h)
        {
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
            rigidBody = GetComponent<Rigidbody2D>();
            colliderObject = GetComponent<Collider2D>();

        }
        void Update()
        {
            if (isStopRun) { return; }
            DeadTime();
        }
        private void IsDead(int getHash, bool _isDead)
        {
            if (thisHash == getHash)
            {
                isDead = _isDead;
                rigidBody.freezeRotation = false;
            }
        }
        private void DeadTime()
        {
            if (isDead)
            {
                if (!isMoveTrigger) { rigidBody.velocity = new Vector2(0, 1) * jampSpeed; isMoveTrigger = !isMoveTrigger; }

                killTime -= Time.deltaTime;
                if (killTime <= 2)
                {
                    colliderObject.enabled = false;
                }
                if (killTime <= 0)
                {
                    killTime = defaultTime; gameObject.SetActive(false);
                }
            }
        }
    }
}

