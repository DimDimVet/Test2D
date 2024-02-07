using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using Zenject;

namespace Healt
{
    public class Healt : MonoBehaviour
    {
        [SerializeField] private HealtSetting settingsHealt;
        private int healtCount, costObject;
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
            healtExecutor.OnGetDamage += Test;
        }
        void Start()
        {
            SetSettings();
            healtExecutor.SetDamage(1,2);
        }
        private void Test(int getHash, int damage)
        {
            Debug.Log($"tst{getHash}--{damage}");
        }
        private void SetSettings()
        {
            healtCount = settingsHealt.HealtCount;
            costObject = settingsHealt.CostObject;
            thisHash=gameObject.GetHashCode();
        }
        private void GetRun()
        {
            if (!isRun)
            {
                isRun=true;
            }
        }
        void Update()
        {
            if (isStopRun) { return; }
            if (!isRun) { GetRun(); }
            //if (settings.IsUpDate) { SetSettings(); settings.IsUpDate = false; }
        }
        private void ControlDamage(int getHash, int damage)
        { 

        }
        private void Healing(int getHash, int healing)
        {
            
        }
    }
}

