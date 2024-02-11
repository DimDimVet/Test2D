using Healt;
using RegistratorObject;
using UnityEngine;
using Zenject;

namespace Bulls
{
    public enum TypeTarget
    {
        Player,
        Enemy,
        Other
    }
    public enum TypeBullet
    {
        Sleeve,
        PlayerBull,
        EnemyBull,
    }
    public class Bull : MonoBehaviour
    {
        [SerializeField] private BulletSettings settings;
        public bool IsForwardPlus { get { return isForwardPlus; } set { isForwardPlus = value; } }
        private Rigidbody2D rbThisObject;
        private TypeBullet typeBullet;
        private float speedBullet;
        private float killTime, defaultTime;
        private int damage;
        private bool isBullKill = true, isShootTriger = true;
        private bool isForwardPlus = true;
        private RaycastHit2D[] hit;
        private float diametrColl;
        private Construction[] dataList;
        private int tempHash;
        private int thisHash;
        private bool isRun = false, isStopRun = false;

        private IRegistrator data;
        private IHealt healtExecutor;
        [Inject]
        public void Init(IHealt h, IRegistrator r)
        {
            data = r;
            healtExecutor = h;
        }

        void Start()
        {
            SetSettings();
        }
        private void SetSettings()
        {
            thisHash = gameObject.GetHashCode();
            typeBullet = settings.TypeBullet;
            speedBullet = settings.SpeedBullet;
            killTime = settings.KillTime;
            defaultTime = settings.KillTime;
            damage = settings.Damage;
            diametrColl = settings.DiametrColl;
        }
        private void GetRun()
        {
            if (!isRun)
            {
                rbThisObject = GetComponent<Rigidbody2D>();
                if (!(rbThisObject is Rigidbody2D)) { this.gameObject.AddComponent<Rigidbody2D>(); }

                dataList = data.SetList();
                if (dataList != null) { isRun = true; return; }

                isRun = false;
            }
        }
        private void FixedUpdate()
        {
            if (isStopRun) { return; }
            if (!isRun) { GetRun(); }
            MoveBull();
        }
        private void MoveBull()
        {
            if (typeBullet != TypeBullet.Sleeve)
            {
                MoveForward();
                isBullKill = true;
                if (CollisionObject())
                { ReternBullet(); }
                if (KillTimeBullet())
                { ReternBullet(); }
            }
            else if (typeBullet == TypeBullet.Sleeve)
            {
                if (isShootTriger) { rbThisObject.AddForce(Vector3.up * speedBullet, ForceMode2D.Impulse); }

                isShootTriger = false;
                isBullKill = true;
                if (KillTimeBullet())
                { isShootTriger = true; ShootSleeve(); }
            }
        }
        private void MoveForward()
        {
            if (isForwardPlus) { rbThisObject.velocity = transform.right * speedBullet; }
            else { rbThisObject.velocity = -transform.right * speedBullet; }
        }
        private bool KillTimeBullet()
        {
            if (isBullKill)
            {
                killTime -= Time.deltaTime;
                if (killTime <= 0)
                {
                    killTime = defaultTime; isBullKill = false; return true;
                }
                return false;
            }
            return false;
        }
        private bool CollisionObject()
        {
            hit = Physics2D.CircleCastAll(gameObject.transform.position, diametrColl, Vector2.zero);
            if (hit != null)
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    tempHash = hit[i].collider.gameObject.GetHashCode();
                    if (tempHash == thisHash) { return false; }
                    if (tempHash != 0) { healtExecutor.SetDamage(tempHash, damage); return true; }
                }
            }

            return false;
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(gameObject.transform.position, diametrColl);
        }
        public virtual void ReternBullet()
        {
        }
        public virtual void ShootSleeve()
        {
        }

    }
}

