using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Input 
{
    public class GetInputPlayer : MonoBehaviour
    {
        private IInput inputData;
        [Inject]
        public void Init(IInput x)
        {
            inputData = x;
        }

        private void Start()
        {
            inputData.Enable();
        }

        // Update is called once per frame
        //void Update()
        //{
        //    Debug.Log(inputData.Updata().Move);
        //    Debug.Log(inputData.Updata().Jamp);
        //}
    }
}

