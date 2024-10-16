using com.asteroids.scripts.Gameplay;
using UnityEngine;

namespace asteroids.scripts
{
    public class LobbyMovementComponent : ICharacterComponent
    {
        private IEnemySettings settings;
        private float speed = 5;
        private float directionDely;

        private Transform transform;
        private Rigidbody2D rigidbody2D;

        private Vector3 directionVector;

        public LobbyMovementComponent(Transform transform, float speed)
        {
            this.transform = transform;
            this.speed = speed;
        }

        public void Start()
        {
        }

        public void Update()
        {
            
        }

        public void FixedUpdate()
        {
            
            var velocity = new Vector3(0,1,0) * speed * Time.deltaTime;
            transform.position += velocity;
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
    }
}