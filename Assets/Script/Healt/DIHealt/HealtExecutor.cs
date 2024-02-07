using System;

namespace Healt
{
    public class HealtExecutor : IHealt
    {

        public Action<int, int> OnGetDamage { get { return onGetDamage; } set { onGetDamage = value; } }
        private  Action<int, int> onGetDamage;

        private void GetDamage(int getHash, int damage)
        {
            onGetDamage?.Invoke(getHash, damage);
        }
        public void SetDamage(int getHash, int damage)
        {
            GetDamage(getHash, damage);
        }
    }
}

