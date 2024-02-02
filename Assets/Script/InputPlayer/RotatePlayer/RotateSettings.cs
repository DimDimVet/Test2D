using UnityEngine;

[CreateAssetMenu(fileName = "RotatseSetting", menuName = "ScriptableObjects/RotatseSetting")]
public class RotatseSetting : ScriptableObject
{
    [Header("�������� ����+"), Range(0, 90)]
    public float AnglePlus = 75f;
    [Header("�������� ����-"), Range(-90, 0)]
    public float AngleMinus = -75f;

    [Header("��������")]
    public bool IsUpDate = false;
}
