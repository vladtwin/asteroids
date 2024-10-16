using UnityEngine;
using Zenject;

namespace com.asteroids.scripts.Gameplay.Game.Scripts.Gameplay.PlayerInputSystem
{
    internal class AndroidInputSystem : IPlayerInputSystem
    {
        private InputSystemProvider inputSystemProvider;

        [Inject]
        public AndroidInputSystem(InputSystemProvider inputSystemProvider)
        {
            this.inputSystemProvider = inputSystemProvider;
        }

        public bool IsFirePressed()
        {
            return inputSystemProvider.PopEvent(InputAction.Fire);
        }

        public Vector2 MoveVector()
        {
            float x, y;
            var left = inputSystemProvider.PopEvent(InputAction.Left);
            var right = inputSystemProvider.PopEvent(InputAction.Right);
            var up = inputSystemProvider.PopEvent(InputAction.Forward);

            if (left && right)
                x = 0;
            else if (left)
                x = -1;
            else if (right)
                x = 1;
            else x = 0;

            y = (up || left || right) ? 1 : 0;

            return new Vector2(x, y);
        }

        public bool IsNitro()
        {
            return inputSystemProvider.PopEvent(InputAction.Nitro);
        }
    }
}