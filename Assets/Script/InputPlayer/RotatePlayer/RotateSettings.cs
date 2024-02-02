using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RotatseSetting", menuName = "ScriptableObjects/RotatseSetting")]
public class RotatseSetting : ScriptableObject
{
    [Header("Скорость поворота"), Range(0, 10)]
    public float RotateSpeed = 5f;
    //[Header("Скорость прыжка"), Range(0, 10)]
    //public float JampSpeed = 5f;

    //[Header("Указать слой GND")]
    //public string TagGnd;
    //[Header("Расстояние до поверхности(коллайдера)"), Range(0, 1)]
    //public float GndDistance = 0.1f;

    [Header("Обновить")]
    public bool IsUpDate = false;
}
