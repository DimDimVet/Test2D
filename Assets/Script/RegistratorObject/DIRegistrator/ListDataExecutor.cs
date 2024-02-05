using System.Collections.Generic;

namespace RegistratorObject
{
    public enum TypeObject
    {
        Player,
        Enemy,
        Other
    }
    public class ListDataExecutor : IRegistrator
    {
        private List<Construction> listData = new List<Construction>();
        private Construction[] temp;
        public void SetData(Construction registrator)
        {
            listData.Add(registrator);
        }
        private List<Construction> GetData()
        {
            return listData;
        }
        public bool ClearData()
        {
            listData.Clear();
            if (listData.Count == 0) { return true; } else { return false; }
        }
        //
        public Construction[] SetList()
        {
            Masiv<Construction> tempMassiv = new Masiv<Construction>();
            listData = GetData();
            for (int i = 0; i < listData.Count; i++)
            {
                if (listData[i].Hash!=0)
                {
                    temp = tempMassiv.Creat(listData[i], temp);
                }
            }
            return temp;
        }
        public Construction SetObjectHash(int hash)
        {
            listData = GetData();
            for (int i = 0; i < listData.Count; i++)
            {
                if (listData[i].Hash == hash)
                {
                    return listData[i];
                }
            }
            return new Construction();
        }
        public Construction[] SetPlayer()
        {
            Masiv<Construction> tempMassiv = new Masiv<Construction>();
            listData = GetData();
            for (int i = 0; i < listData.Count; i++)
            {
                if (listData[i].TypeObject is TypeObject.Player)
                {
                    temp = tempMassiv.Creat(listData[i], temp);
                }
            }
            return temp;
        }
        public Construction[] SetEnemys()
        {
            Masiv<Construction> tempMassiv = new Masiv<Construction>();
            listData = GetData();
            for (int i = 0; i < listData.Count; i++)
            {
                if (listData[i].TypeObject is TypeObject.Enemy)
                {
                    temp = tempMassiv.Creat(listData[i], temp);
                }
            }
            return temp;
        }
    }
}

