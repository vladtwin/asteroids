using System;
using com.asteroids.scripts.Gameplay.Game.Scripts.Gameplay.PlayerInputSystem;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace com.asteroids.scripts.Gameplay
{
    public class FireComponent : ICharacterComponent
    {
        protected GameObject bulletPrefab;
        protected int bulletCount = 5;
        protected float bulletSpeed = 10f;
        protected Transform firePoint;
        protected ObjectPool<BulletComponent> bulletPool;
        protected Action<BulletComponent> onFire;
        protected Transform playerPosition;

        public Action<GameObject> onHit;

        public Action<BulletComponent> OnFire
        {
            get => onFire;
            set => onFire = value;
        }

        public FireComponent(Transform firePoint, Transform playerPosition, GameObject bulletPrefab, int bulletCount,
            float bulletSpeed)
        {
            this.firePoint = firePoint;
            bulletPool = new ObjectPool<BulletComponent>(ObCreateBullet(), OnTakeBulletFromPool(), OnReturnBulletToPool,
                null, true, bulletCount);

            this.bulletPrefab = bulletPrefab;
            this.bulletCount = bulletCount;
            this.bulletSpeed = bulletSpeed;
            this.playerPosition = playerPosition;
        }

        public bool Fire()
        {
            if (bulletCount <= 0)
                return false;

            bulletCount--;
            var bullet = bulletPool.Get();
            var direction = firePoint.position - playerPosition.position;

            bullet.transform.position = firePoint.position;
            bullet.Init(direction, bulletSpeed, o =>
            {
                try
                {
                    bulletCount++;
                    onHit?.Invoke(o);
                    bulletPool.Release(bullet);
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            });

            OnFire?.Invoke(bullet);

            return true;
        }

        public virtual void Start()
        {
        }

        public virtual void Update()
        {
           
        }

        public virtual void FixedUpdate()
        {
        }

        public void Restart()
        {
            
        }

        public void OnDamage()
        {
            
        }

        public void OnHitEnemy()
        {
        }

        private void OnReturnBulletToPool(BulletComponent obj)
        {
            obj.gameObject.SetActive(false);
        }

        private Action<BulletComponent> OnTakeBulletFromPool() => component =>
        {
            component.gameObject.transform.position = firePoint.position;
            component.gameObject.SetActive(true);
        };

        private Func<BulletComponent> ObCreateBullet() =>
            () =>
                Object.Instantiate(bulletPrefab).GetComponent<BulletComponent>();
    }
}