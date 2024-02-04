using UnityEngine;

namespace RegistratorObject
{
    public enum TypeObject
    {
        Player,
        Enemy,
        Other
    }
    public class Registrator : MonoBehaviour
    {
        public TypeObject type;
        private int thisHash;


        void Start()
        {
            thisHash=gameObject.GetHashCode();  
            Construction registrator = new Construction
            {
                Hash = thisHash,
                TypeObject = type
            };
            BaseObject.CreatData(registrator);
        }

    }
}

