using UnityEngine;

namespace com.asteroids.scripts.Gameplay.Game.Scripts.Gameplay.PlayerInputSystem
{
    public interface IPlayerInputSystem 
    {
        public bool IsFirePressed();
        public Vector2 MoveVector();
        public bool IsNitro();
    }
}
