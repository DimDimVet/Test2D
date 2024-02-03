using Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bull : MonoBehaviour
{
    ////
    //private IInput inputData;
    //[Inject]
    //public void Init(IInput x)
    //{
    //    inputData = x;
    //}
    ////
    void Start()
    {
        Debug.Log(gameObject.GetHashCode());
    }
    public class Factory : PlaceholderFactory<Bull>
    {
    }
}
