using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RotatseSetting", menuName = "ScriptableObjects/RotatseSetting")]
public class RotatseSetting : ScriptableObject
{
    [Header("�������� ��������"), Range(0, 10)]
    public float RotateSpeed = 5f;
    //[Header("�������� ������"), Range(0, 10)]
    //public float JampSpeed = 5f;

    //[Header("������� ���� GND")]
    //public string TagGnd;
    //[Header("���������� �� �����������(����������)"), Range(0, 1)]
    //public float GndDistance = 0.1f;

    [Header("��������")]
    public bool IsUpDate = false;
}
