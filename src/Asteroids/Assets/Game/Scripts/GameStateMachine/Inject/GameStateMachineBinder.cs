using Zenject;

namespace com.asteroids.scripts.StateMachine.Game.Scripts.GameStateMachine.Inject
{
    public class GameStateMachineBinder
    {
        private readonly DiContainer container;

        [Inject]
        public GameStateMachineBinder(DiContainer container) =>
            this.container = container;

        public GameStateBinder BindStateMachine<TStateMachine>()
            where TStateMachine : class, IGameStateMachine
        {
            container.BindInterfacesAndSelfTo<TStateMachine>().AsSingle();
            return new GameStateBinder(container, typeof(TStateMachine));
        }
    }
}