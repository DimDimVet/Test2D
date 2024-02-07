using Bulls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletSettings", menuName = "ScriptableObjects/BulletSettings")]
public class BulletSettings : ScriptableObject
{
    [Header("Типы пули-снаряда")]
    public TypeBullet TypeBullet;
    [Header("Типы целей")]
    public TypeTarget[] TypeTarget;
    [Header("Скорость пули")]
    public float SpeedBullet = 5f;
    [Header("Время жизни пули")]
    public float KillTime = 5f;
    [Header("Диаметр коллайдера"), Range(0, 1)]
    public float DiametrColl = 0.1f;
    [Header("Дамаг")]
    public float Damage = 1f;
    [Header("Процент критического дамага"), Range(0, 100)]
    public float PercentDamage = 50f;

    [Header("Обновить")]
    public bool IsUpDate = false;
}


