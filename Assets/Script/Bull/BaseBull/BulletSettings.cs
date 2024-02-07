using Bulls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletSettings", menuName = "ScriptableObjects/BulletSettings")]
public class BulletSettings : ScriptableObject
{
    [Header("���� ����-�������")]
    public TypeBullet TypeBullet;
    [Header("���� �����")]
    public TypeTarget[] TypeTarget;
    [Header("�������� ����")]
    public float SpeedBullet = 5f;
    [Header("����� ����� ����")]
    public float KillTime = 5f;
    [Header("������� ����������"), Range(0, 1)]
    public float DiametrColl = 0.1f;
    [Header("�����")]
    public float Damage = 1f;
    [Header("������� ������������ ������"), Range(0, 100)]
    public float PercentDamage = 50f;

    [Header("��������")]
    public bool IsUpDate = false;
}


