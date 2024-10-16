using UnityEngine;

namespace asteroids.scripts
{
    public interface IEnemySettings
    {
        public float MinSpeed { get; }
        public float MaxSpeed { get; }

        public float MinChangeDirectionTime { get; }
        public float MaxChangeDirectionTime { get; }

        public float MinFireDelay { get; }
        public float MaxFireDelay { get; }
        GameObject BulletPrefab { get; }
        int BulletsCount { get;  }
        float BulletSpeed { get; }
    }
}