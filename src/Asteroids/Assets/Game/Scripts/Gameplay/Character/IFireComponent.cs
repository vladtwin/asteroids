using System;
using UnityEngine;

namespace com.asteroids.scripts.Gameplay
{
    public interface IFireComponent
    {
        public Action<BulletComponent> OnFire { get; set; }
        public bool Fire(Vector3 direction, Action<GameObject> bulletCollision);
    }
}