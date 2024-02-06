using UnityEngine;
using Zenject;

namespace RegistratorObject
{

    public class Registrator : MonoBehaviour
    {
        public TypeObject type;
        public int thisHash;
        private IRegistrator registrator;
        [Inject]
        public void Init(IRegistrator r)
        {
            registrator = r;
        }

        void Start()
        {
            thisHash=gameObject.GetHashCode();  
            Construction element = new Construction
            {
                Hash = thisHash,
                TypeObject = type,
                Object=gameObject
            };
            registrator.SetData(element);
        }

    }
}

