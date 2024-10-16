using com.asteroids.scripts.Gameplay.Game.Scripts.Gameplay.PlayerInputSystem;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace com.asteroids.Gameplay.PlayerInputSystem.Inject
{
    public static class InjectExtensions
    {
        public static void BindPlayerInputSystem(this DiContainer diContainer)
        {

#if UNITY_EDITOR
            diContainer.BindInterfacesAndSelfTo<EditorInputSystem>().AsSingle();
#elif UNITY_ANDROID
                diContainer.BindInterfacesAndSelfTo<AndroidInputSystem>().AsSingle();

#else
                diContainer.BindInterfacesAndSelfTo<WindowsInputSystem>().AsSingle();
#endif

            diContainer.Bind<InputSystemProvider>().AsSingle();
        }
    }
}