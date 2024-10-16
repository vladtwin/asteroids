using Zenject;

namespace com.asteroids.scripts.StateMachine.Game.Scripts.GameStateMachine.Inject
{
    public static class GameStateMachineInjectExtension
    {
        public static GameStateMachineBinder DiStateMachine(this DiContainer container) => 
            new GameStateMachineBinder(container);
    }
}