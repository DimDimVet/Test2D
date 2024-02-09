using PlasticPipe.PlasticProtocol.Server.Stubs;
using RegistratorObject;
using UnityEngine;
using Zenject;

namespace Loot
{
    public class Loot : MonoBehaviour
    {
        public int Healt { get { return healt; } }
        [SerializeField] private LootSettings lootSettings;
        private RaycastHit2D[] hit;
        private float diametrColl;
        private int tempHash;
        private int healt;
        private Construction[] dataList;
        private bool isRun = false, isStopRun = false;

        private IRegistrator data;
        [Inject]
        public void Init(IRegistrator r)
        {
            data = r;
        }
        void Start()
        {
            SetSettings();
        }
        private void SetSettings()
        {
            diametrColl = lootSettings.DiametrColl;
            healt = lootSettings.Healt;
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
            CollisionObject();

        }
        private bool CollisionObject()
        {
            hit = Physics2D.CircleCastAll(gameObject.transform.position, diametrColl, Vector2.zero);
            if (hit != null)
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    tempHash = hit[i].collider.gameObject.GetHashCode();
                    FindPlayer(tempHash);
                }
            }
            return false;
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(gameObject.transform.position, diametrColl);
        }
        private void FindPlayer(int hash)
        {
            if (hash == 0 || dataList==null) { return; }

            for (int i = 0; i < dataList.Length; i++)
            {
                if (dataList[i].Hash==hash & dataList[i].TypeObject == TypeObject.Player) 
                { Executor(dataList[i]);}
            }
            ReternLoot();
            
        }
        public virtual void Executor(Construction player)
        {
        }
        public virtual void ReternLoot()
        {
        }
    }
}

