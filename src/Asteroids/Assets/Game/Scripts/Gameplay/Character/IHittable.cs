using UnityEngine;

namespace com.asteroids.scripts.Gameplay
{
    public interface IHittable
    {
        public void Hit(GameObject source);
    }
}