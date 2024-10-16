using EZCameraShake;
using UnityEngine;

namespace com.asteroids.scripts.Gameplay
{
    public class CameraShakerComponent : ICharacterComponent
    {
        private CameraShaker cameraShaker;
        public CameraShakerComponent(CameraShaker cameraShaker)
        {
            this.cameraShaker = cameraShaker;
        }

        public void Start()
        {
        }

        public void Update()
        {
        }

        public void FixedUpdate()
        {
        }

        public void Restart()
        {
        }

        public void OnDamage()
        {
            cameraShaker.ShakeOnce(2,10,0,5);
        }

        public void OnHitEnemy()
        { 
            cameraShaker.ShakeOnce(1,3,0,1);
        }
    }
}