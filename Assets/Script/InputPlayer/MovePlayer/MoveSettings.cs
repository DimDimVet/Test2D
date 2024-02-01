using UnityEngine;

[CreateAssetMenu(fileName = "MoveSettings", menuName = "ScriptableObjects/MoveSettings")]
public class MoveSettings : ScriptableObject
{
    [Header("�������� ������")]
    public float SpeedForward = 1f;
    [Header("�������� �����")]
    public float SpeedBack = 1f;
    [Header("�������� ��������")]
    public float SpeedTurn = 0.1f;

    [Header("��� ������(�����. 50)")]
    public float Weight = 50f;

    [Header("������� ���� GND")]
    public LayerMask GroundLayer;

    [Header("�������� �������")]
    public float ShootDelay = 1f;

    [Header("��������")]
    public bool IsUpDate = false;
}
