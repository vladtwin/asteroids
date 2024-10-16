using System.Collections.Generic;
using System.Linq;
using com.asteroids.scripts.Gameplay.Game.Scripts.Gameplay.PlayerInputSystem;
using EZCameraShake;
using UnityEngine;
using Zenject;

namespace com.asteroids.scripts.Gameplay
{
    public class PlayerShip : EntityBase
    {
        public Transform bulletSpawnPoint;
        public  Animator PlayerAnimator;
        public CameraShaker CameraShaker;

        private IPlayerShipSettings settings;
        private FireComponent fireComponent;
        
        [Inject]
        public void Construct(IPlayerShipSettings playerSettings, IPlayerInputSystem inputSystem)
        {
            settings = playerSettings;
            fireComponent = new PlayerFireComponent(bulletSpawnPoint, transform, playerSettings.BulletPrefab,
                playerSettings.BulletCount,
                playerSettings.BulletSpeed, inputSystem);
            var movement = new CharacterMovement(inputSystem, settings, transform);
            var cameraShaker = new CameraShakerComponent(CameraShaker);

            CharacterComponents = new List<ICharacterComponent>();
            CharacterComponents.Add(movement);
            CharacterComponents.Add(fireComponent);
            CharacterComponents.Add(new MovementAnimationController(movement, PlayerAnimator));
            CharacterComponents.Add(cameraShaker);

            fireComponent.onHit += e=>
            {
                if (e.GetComponent<IHittable>() == null)
                    return;
                
                CallOnKill();
            };
        }
        
    }
}