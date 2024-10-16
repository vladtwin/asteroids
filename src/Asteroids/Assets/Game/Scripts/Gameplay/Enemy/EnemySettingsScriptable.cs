using UnityEngine;
using UnityEngine.Serialization;

namespace asteroids.scripts
{
    [CreateAssetMenu(menuName = "Game/Enemy Ship Settings")]
    public class EnemySettingsScriptable : ScriptableObject, IEnemySettings
    {
        [SerializeField] public float minSpeed = 2.5f;
        [SerializeField] public float maxSpeed = 4.5f;
        [SerializeField] public float minChangeDirectionTime = 5f;
        [SerializeField] public float maxChangeDirectionTime = 15f;
        [SerializeField] public float minFireDelay = 3f;
        [SerializeField] public float maxFireDelay = 5f;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private int bulletsCount = 2;
        [SerializeField] private float bulletSpeed = 4;

        public float MinSpeed => minSpeed;
        public float MaxSpeed => maxSpeed;
        public float MinChangeDirectionTime => minChangeDirectionTime;
        public float MaxChangeDirectionTime => maxChangeDirectionTime;
        public float MinFireDelay => minFireDelay;
        public float MaxFireDelay => maxFireDelay;
        public GameObject BulletPrefab => bulletPrefab;
        public int BulletsCount => bulletsCount;
        public float BulletSpeed => bulletSpeed;
    }
}