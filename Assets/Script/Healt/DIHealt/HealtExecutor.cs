using RegistratorObject;
using System;
using Zenject;

namespace Healt
{
    public class HealtExecutor : IHealt
    {
        private Construction[] dataList, rezult;
        private Masiv<Construction> massiv;

        public Action<int, int> OnGetDamage { get { return onGetDamage; } set { onGetDamage = value; } }
        private  Action<int, int> onGetDamage;

        public Action<int, int, int> OnStatisticHealt { get { return onStatisticHealt; } set { onStatisticHealt = value; } }
        private Action<int, int, int> onStatisticHealt;
        //
        private IRegistrator data;
        [Inject]
        public void Init(IRegistrator r)
        {
            data = r;
        }

        private void GetDamage(int getHash, int damage)
        {
            onGetDamage?.Invoke(getHash, damage);
        }
        public void SetDamage(int getHash, int damage)
        {
            if (dataList == null) { dataList = data.SetList(); }
            for (int i = 0;i<dataList.Length;i++) 
            {
                if (dataList[i].Hash == getHash && !dataList[i].isDead) { GetDamage(getHash, damage); }
            }
        }
        public void StatisticHealt(int getHash, int currentHealt, int maxHealt)
        {
            onStatisticHealt?.Invoke(getHash, currentHealt, maxHealt);
        }
        public void DeadObject(int getHash, int costObject)
        {
            for (int i = 0; i < dataList.Length; i++)
            {
                if (dataList[i].Hash == getHash) { dataList[i].isDead=true; }
            }
        }
    }
}

