using RegistratorObject;
using UnityEngine;
[CreateAssetMenu(fileName = "MoveEnemySettings", menuName = "ScriptableObjects/MoveEnemySettings")]
public class MoveEnemySettings : ScriptableObject
{

    [Header("Цель движения")]
    public TypeObject TypeObject;
    [Header("Скорость движения"), Range(0, 20)]
    public float MoveSpeed = 5f;
    [Header("Скорость прыжка"), Range(0, 20)]
    public float JampSpeed = 5f;
    [Header("Стоп дистанция до цели"), Range(0, 50)]
    public float StopDistance = 5f;

    [Header("Указать слой GND")]
    public string TagGnd="Gnd";
    [Header("Расстояние до поверхности(коллайдера)"), Range(0, 1)]
    public float GndDistance = 0.1f;

    [Header("Обновить")]
    public bool IsUpDate = false;
}
