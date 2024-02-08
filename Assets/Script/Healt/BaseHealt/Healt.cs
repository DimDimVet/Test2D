using UnityEngine;
using Zenject;

namespace Healt
{
    public class Healt : MonoBehaviour
    {
        [SerializeField] private HealtSetting settingsHealt;
        private int healtCount, maxHealt, costObject;
        private int thisHash;
        private bool isRun = false, isStopRun = false;

        private IHealt healtExecutor;
        [Inject]
        public void Init(IHealt h)
        {
            healtExecutor = h;
        }
        private void OnEnable()
        {
            healtExecutor.OnGetDamage += ControlDamage;
        }
        void Start()
        {
            SetSettings();
        }
        private void SetSettings()
        {
            thisHash = gameObject.GetHashCode();
            healtCount = settingsHealt.HealtCount;
            maxHealt = healtCount;
            costObject = settingsHealt.CostObject;
            healtExecutor.StatisticHealt(thisHash, healtCount, maxHealt);
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
        }
        private void ControlDamage(int getHash, int damage)
        {
          if (thisHash == getHash && !isStopRun)
            {
                if (healtCount > 0) { healtCount = healtCount - damage; healtExecutor.StatisticHealt(getHash, healtCount, maxHealt); }
                if (healtCount <= 0) { healtExecutor.DeadObject(getHash, costObject); isStopRun = true; }
            }
        }
        private void Healing(int getHash, int healing)
        {

        }
    }
}

