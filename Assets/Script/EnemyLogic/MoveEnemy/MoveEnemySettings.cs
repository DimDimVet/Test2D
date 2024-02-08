using RegistratorObject;
using UnityEngine;
[CreateAssetMenu(fileName = "MoveEnemySettings", menuName = "ScriptableObjects/MoveEnemySettings")]
public class MoveEnemySettings : ScriptableObject
{

    [Header("���� ��������")]
    public TypeObject TypeObject;
    [Header("�������� ��������"), Range(0, 20)]
    public float MoveSpeed = 5f;
    [Header("�������� ������"), Range(0, 20)]
    public float JampSpeed = 5f;
    [Header("���� ��������� �� ����"), Range(0, 50)]
    public float StopDistance = 5f;

    [Header("������� ���� GND")]
    public string TagGnd="Gnd";
    [Header("���������� �� �����������(����������)"), Range(0, 1)]
    public float GndDistance = 0.1f;

    [Header("��������")]
    public bool IsUpDate = false;
}
