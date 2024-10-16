using UnityEngine;

namespace com.asteroids.scripts.Gameplay
{
    public interface IPlayerShipSettings
    {
        GameObject BulletPrefab { get; }
        int BulletCount { get; }
        float BulletSpeed { get; }
        float MaxMoveSpeed { get; }
        float MaxNitroMoveSpeed { get; }
        float TimeToMaxSpeed { get; }
        float TimeToMaxSpeedNitro { get; }
        float RotationSpeed { get; }
        AnimationCurve VelocityCurve { get; }
        AnimationCurve NitroVelocityCurve { get; }
        float FreeMoveTime { get; }
    }
}