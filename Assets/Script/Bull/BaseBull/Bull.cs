using Input;
using Pools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static UnityEngine.UI.CanvasScaler;

namespace Bulls
{
    public enum TypeTarget
    {
        Player,
        Enemy,
        Other
    }
    public enum TypeBullet
    {
        Sleeve,
        PlayerBull,
        EnemyBull,
    }
    public class Bull : MonoBehaviour
    {
        [SerializeField] private BulletSettings settings;
        public bool IsForwardPlus { get { return isForwardPlus; }set { isForwardPlus = value; } }
        private Rigidbody2D rbThisObject;
        private TypeBullet typeBullet;
        private TypeTarget[] typeTarget;
        private float speedBullet;
        private float killTime, defaultTime;
        private float damage, percentDamage;
        private bool isBullKill = true, isShootTriger = true;
        private bool isForwardPlus=true;

        private bool isRun = false, isStopRun = false;

        void Start()
        {
            SetSettings();
        }
        private void SetSettings()
        {
            typeBullet = settings.TypeBullet;
            typeTarget=settings.TypeTarget;
            speedBullet = settings.SpeedBullet;
            killTime = settings.KillTime;
            defaultTime = settings.KillTime;
            damage = settings.Damage;
            percentDamage = settings.PercentDamage;
        }
        private void GetRun()
        {
            if (!isRun)
            {
                rbThisObject = GetComponent<Rigidbody2D>();
                if (!(rbThisObject is Rigidbody2D)) { this.gameObject.AddComponent<Rigidbody2D>(); }
                isRun = true;
            }
        }
        private void FixedUpdate()
        {
            if (isStopRun) { return; }
            if (!isRun) { GetRun(); }
            if (settings.IsUpDate) { SetSettings(); settings.IsUpDate = false; }
            MoveBull();
        }
        private void MoveBull()
        {
            if (typeBullet != TypeBullet.Sleeve)
            {
                MoveForward();
                isBullKill = true;
                if (CollisionObject())
                { ReternBullet(); }
                if (KillTimeBullet())
                { ReternBullet(); }
            }
            else if (typeBullet == TypeBullet.Sleeve)
            {
                if (isShootTriger) { rbThisObject.AddForce(Vector3.up * speedBullet, ForceMode2D.Impulse); }

                isShootTriger = false;
                isBullKill = true;
                if (KillTimeBullet())
                { isShootTriger = true; ShootSleeve(); }
            }
        }
        private void MoveForward()
        {
            if (isForwardPlus) { rbThisObject.velocity = transform.right * speedBullet; }
            else { rbThisObject.velocity = -transform.right * speedBullet; }
        }
        private bool KillTimeBullet()
        {
            if (isBullKill)
            {
                killTime -= Time.deltaTime;
                if (killTime <= 0)
                {
                    killTime = defaultTime; isBullKill = false; return true;
                }
                return false;
            }
            return false;
        }
        private bool CollisionObject()
        {
            return false; /*DetectObject();*/
        }
        public virtual void ReternBullet()
        {
        }
        public virtual void ShootSleeve()
        {
        }

    }
}

