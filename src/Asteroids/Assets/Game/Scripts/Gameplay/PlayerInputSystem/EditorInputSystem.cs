using UnityEngine;
using Zenject;

namespace com.asteroids.scripts.Gameplay.Game.Scripts.Gameplay.PlayerInputSystem
{
    internal class EditorInputSystem : IPlayerInputSystem
    {
        
        private WindowsInputSystem windowsInputSystem;
        private AndroidInputSystem androidInputSystem;
      
        [Inject]
        public EditorInputSystem(InputSystemProvider inputSystemProvider)
        {
            windowsInputSystem = new WindowsInputSystem();
            androidInputSystem = new AndroidInputSystem(inputSystemProvider);
        }
        public bool IsFirePressed()
        {
            return androidInputSystem.IsFirePressed() || windowsInputSystem.IsFirePressed();
        }

        public Vector2 MoveVector()
        {
            var androidVector = androidInputSystem.MoveVector();
            return androidVector != Vector2.zero ? androidVector : windowsInputSystem.MoveVector();
        }

        public bool IsNitro()
        {
            return androidInputSystem.IsNitro() || windowsInputSystem.IsNitro();
        }
    }
}