using Shoot;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootSettings", menuName = "ScriptableObjects/ShootSettings")]
public class ShootSettings : ScriptableObject
{
    [Header("����� ����������� ����")]
    public float CurrentTime = 5f;
    [Header("���������� � ��������")]
    public int MaxCountClip = 1;

    [Header("����� ����������� ��������(��������� ��� ���������� � �������� ����� 1)")]
    public float CurrentTimeClip = 5f;

    [Header("����� ����������")]
    public ModeShoot ModeShoot;

    [Header("��������")]
    public bool IsUpDate = false;

}
