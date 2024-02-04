using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patter : MonoBehaviour
{
    private bool isRun = false, isStopRun = false;
    private void Awake()
    {
        
    }
    private void OnEnable()
    {
        
    }
    void Start()
    {
        SetSettings();
    }
    private void SetSettings()
    {
        
    }
    private void GetRun()
    {
        if (!isRun)
        {
            
        }
    }
    void Update()
    {
        if (isStopRun) { return; }
        if (!isRun) { GetRun(); }
        //if (settings.IsUpDate) { SetSettings(); settings.IsUpDate = false; }
    }
    private void FixedUpdate()
    {
        
    }
    private void OnDisable()
    {
        
    }
}
