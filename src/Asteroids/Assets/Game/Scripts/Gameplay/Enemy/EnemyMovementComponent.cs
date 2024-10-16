using com.asteroids.scripts.Gameplay;
using UnityEngine;

namespace asteroids.scripts
{
    public class EnemyMovementComponent : ICharacterComponent
    {
        private IEnemySettings settings;
        private float speed;
        private float directionDely;

        private Transform transform;
        private Rigidbody2D rigidbody2D;

        private Vector3 directionVector;
        private float collisionDely;

        public EnemyMovementComponent(Transform transform, IEnemySettings settings, Rigidbody2D rigidbody2D)
        {
            this.transform = transform;
            this.settings = settings;
            this.rigidbody2D = rigidbody2D;
        }

        public void Start()
        {
            speed = Random.Range(settings.MinSpeed, settings.MaxSpeed);
            ChangeDirection();
        }

        public void Update()
        {
            directionDely -= Time.deltaTime;
            if (directionDely <= 0)
            {
                directionDely = Random.Range(settings.MinChangeDirectionTime, settings.MaxChangeDirectionTime);
                ChangeDirection();
            }
        }


        public void FixedUpdate()
        {
            
            if (rigidbody2D.IsTouching(new ContactFilter2D()) && collisionDely > 0.1f)
            {
                collisionDely = 0f;
                directionVector = directionVector * -1;
            }
            
            var velocity = directionVector * speed * Time.deltaTime;
            transform.position += velocity;
            collisionDely += Time.deltaTime;
            
            var angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
         
        }

        public void Restart()
        {
            
        }

        public void OnDamage()
        {
            ChangeDirection();
        }

        public void OnHitEnemy()
        {
        }

        private void ChangeDirection()
        {
            var x = Random.Range(-1, 1f);
            var y = Random.Range(-1, 1f);
            directionVector = new Vector3(x, y, 0).normalized;
        }
    }
}