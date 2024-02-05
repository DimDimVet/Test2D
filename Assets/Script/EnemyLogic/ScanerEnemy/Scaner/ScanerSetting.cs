using EnemyLogic;
using RegistratorObject;
using UnityEngine;

[CreateAssetMenu(fileName = "ScanerSetting", menuName = "ScriptableObjects/ScanerSetting")]
public class ScanerSetting : ScriptableObject
{
    [Header("Объекты слежения")]
    public TypeObject[] DetectObject;
    [Header("Дистанция сканера"), Range(1, 100)]
    public float DistanceScaner = 10f;

    [Header("Обновить")]
    public bool IsUpDate = false;
}
