using UnityEngine;
using UnityEngine.Serialization;

namespace com.asteroids.scripts.Gameplay
{
    [CreateAssetMenu(menuName = "Game/Player Ship Settings")]
    public class PlayerShipSettingsScriptable : ScriptableObject, IPlayerShipSettings
    {
        [SerializeField] private float maxMoveSpeed = 4f;
        [SerializeField] private float maxNitroMoveSpeed = 6f;
        [SerializeField] private float timeToMaxSpeed = 6.0f;
        [SerializeField] private float timeToMaxSpeedNitro = 10.0f;
        [SerializeField] private float rotationSpeed = 100f;
        [SerializeField] private AnimationCurve velocityCurve;
        [SerializeField] private AnimationCurve nitroVelocityCurve;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private int bulletCount =5;
        [SerializeField] private float bulletSpeed = 10f;
        [SerializeField] private float freeMoveTime = 4f;

        public GameObject BulletPrefab => bulletPrefab;
        public int BulletCount => bulletCount;
        public float BulletSpeed => bulletSpeed;
        public float MaxMoveSpeed => maxMoveSpeed;
        public float MaxNitroMoveSpeed => maxNitroMoveSpeed;
        public float TimeToMaxSpeed => timeToMaxSpeed;
        public float TimeToMaxSpeedNitro => timeToMaxSpeedNitro;
        public float RotationSpeed => rotationSpeed;
        public AnimationCurve VelocityCurve => velocityCurve;
        public AnimationCurve NitroVelocityCurve => nitroVelocityCurve;
        public float FreeMoveTime => freeMoveTime;
    }
}