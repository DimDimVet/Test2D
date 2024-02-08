using RegistratorObject;
using UnityEngine;
using Zenject;

namespace Loot
{
    public class Loot : MonoBehaviour
    {
        [SerializeField] private LootSettings lootSettings;
        private RaycastHit2D[] hit;
        private float diametrColl;
        private int tempHash;
        private Construction[] dataList;
        private bool isStopRun = false;

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
            if (dataList == null) { dataList = data.SetList(); }
            diametrColl=lootSettings.DiametrColl;
        }
        void Update()
        {
            if (isStopRun) { return; }
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
            if (hash == 0) { return; }
            for (int i = 0; i < dataList.Length; i++)
            {
                if (dataList[i].TypeObject == TypeObject.Player) { Executor(dataList[i]); }
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

