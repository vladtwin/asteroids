using com.asteroids.scripts.StateMachine.Game.Scripts.GameStateMachine;
using Zenject;

namespace com.asteroids.scripts.Installer.Game.Scripts.Installer
{
    internal class StateMachineBootstrap  : IInitializable
    {
        [Inject]
        private IGameStateMachine gameStateMachine;
    
        public void Initialize()
        {
            gameStateMachine.StartStateMachine(TransitionPayload.Create<LoadingState, EmptyPayload>(null));
        }
    }
}