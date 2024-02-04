using RegistratorObject;

namespace RegistratorObject
{
    public static class BaseObject
    {
        private static Construction[] baseObject;
        private static Masiv<Construction> massiv=new Masiv<Construction>();

        public static void CreatData(Construction construction)
        {
            baseObject = massiv.Creat(construction, baseObject);
        }
        public static Construction[] GetAll()
        {
            return baseObject;
        }
        public static Construction[] GetPlayer()
        {
            Construction[] temp = null;
            for (int i = 0; i < baseObject.Length; i++)
            {
                if (baseObject[i].TypeObject == TypeObject.Player)
                {
                    temp = massiv.Creat(baseObject[i], temp);
                }
            }
            return temp;
        }
        public static Construction[] GetEnemys()
        {
            Construction[] temp = null;
            for (int i = 0; i < baseObject.Length; i++)
            {
                if (baseObject[i].TypeObject == TypeObject.Enemy)
                {
                    temp = massiv.Creat(baseObject[i], temp);
                }
            }
            return temp;
        }

    }
}

