using Bulls;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletSettings", menuName = "ScriptableObjects/BulletSettings")]
public class BulletSettings : ScriptableObject
{
    [Header("Типы пули-снаряда")]
    public TypeBullet TypeBullet;
    [Header("Типы целей")]
    public float SpeedBullet = 5f;
    [Header("Время жизни пули")]
    public float KillTime = 5f;
    [Header("Диаметр коллайдера"), Range(0, 1)]
    public float DiametrColl = 0.1f;
    [Header("Дамаг")]
    public int Damage = 1;
}


