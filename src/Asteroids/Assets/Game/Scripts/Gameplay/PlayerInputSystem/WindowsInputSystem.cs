using System;
using UnityEngine;

namespace com.asteroids.scripts.Gameplay.Game.Scripts.Gameplay.PlayerInputSystem
{
    internal class WindowsInputSystem : IPlayerInputSystem
    {
        public bool IsFirePressed()
        {
            return Input.GetButtonDown("Jump");
        }

        public bool IsNitro()
        {
            return Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        }

        public Vector2 MoveVector()
        {
            var horizontal = Math.Sign(Input.GetAxis("Horizontal"));
            var vertical = Input.GetAxis("Vertical") > 0 ? 1 : 0;
            return new Vector2(horizontal, vertical);
        }
    }
}