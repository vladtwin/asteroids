using System;
using com.asteroids.scripts.Gameplay.Game.Scripts.Gameplay.PlayerInputSystem;
using UnityEngine;
using Zenject;

namespace com.asteroids.scripts.Gameplay
{
    public class BulletComponent : MonoBehaviour
    {
        [SerializeField]
        private Vector3 direction;
        [SerializeField]
        private float speed;
        private Action<GameObject> onHit;

      

        public void Init(Vector3 direction, float bulletSpeed, Action<GameObject> action)
        {
            this.direction = direction;
            this.speed = bulletSpeed;
            this.onHit = action;
            
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

        public void Update()
        {
            transform.position += direction * speed * Time.deltaTime;
        }
        
        public void OnTriggerEnter2D(Collider2D collision)
        {
            var hittable = collision.GetComponent<IHittable>();
            if (hittable != null)
                hittable.Hit(gameObject);
            
            onHit?.Invoke(collision.gameObject);
        }
    }
}