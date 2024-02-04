using EnemyLogic;
using RegistratorObject;
using UnityEngine;

[CreateAssetMenu(fileName = "ScanerSetting", menuName = "ScriptableObjects/ScanerSetting")]
public class ScanerSetting : ScriptableObject
{
    [Header("������� ��������")]
    public TypeObject[] DetectObject;
    [Header("��������� �������"), Range(1, 100)]
    public float DistanceScaner = 10f;

    [Header("��������")]
    public bool IsUpDate = false;
}
