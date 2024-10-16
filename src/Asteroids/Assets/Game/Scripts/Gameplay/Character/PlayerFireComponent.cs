using com.asteroids.scripts.Gameplay.Game.Scripts.Gameplay.PlayerInputSystem;
using UnityEngine;

namespace com.asteroids.scripts.Gameplay
{
    public class PlayerFireComponent : FireComponent
    {
        private IPlayerInputSystem inputSystem;

        public PlayerFireComponent(Transform firePoint, Transform playerPosition, GameObject bulletPrefab, int bulletCount, float bulletSpeed, IPlayerInputSystem inputSystem) : base(firePoint, playerPosition, bulletPrefab, bulletCount, bulletSpeed)
        {
            this.inputSystem = inputSystem;
        }

        public override void Update()
        {
            if (inputSystem.IsFirePressed())
            {
                Fire();
            }
        }
    }
}