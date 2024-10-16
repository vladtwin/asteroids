using UnityEngine;

namespace asteroids.scripts
{
    public class EnemySettingsMoc : IEnemySettings
    {
        public float MinSpeed { get; }
        public float MaxSpeed { get; }
        public float MinChangeDirectionTime { get; }
        public float MaxChangeDirectionTime { get; }
        public float MinFireDelay { get; }
        public float MaxFireDelay { get; }
        public GameObject BulletPrefab { get; }
        public int BulletsCount { get; }
        public float BulletSpeed { get; }

        public EnemySettingsMoc(float minSpeed, float maxSpeed, float minChangeDirectionTime, float maxChangeDirectionTime, float minFireDelay, float maxFireDelay, GameObject bulletPrefab, int bulletsCount, float bulletSpeed)
        {
            MinSpeed = minSpeed;
            MaxSpeed = maxSpeed;
            MinChangeDirectionTime = minChangeDirectionTime;
            MaxChangeDirectionTime = maxChangeDirectionTime;
            MinFireDelay = minFireDelay;
            MaxFireDelay = maxFireDelay;
            BulletPrefab = bulletPrefab;
            BulletsCount = bulletsCount;
            BulletSpeed = bulletSpeed;
        }
    }
}