using System;
using System.Collections.Generic;
using Zenject;

namespace com.asteroids.scripts.StateMachine.Game.Scripts.GameStateMachine.Inject
{
    public class GameStateBinder
    {
        private readonly DiContainer container;
        private Type stateMachineType;

        public GameStateBinder(DiContainer container, Type stateMachineType)
        {
            this.container = container;
            this.stateMachineType = stateMachineType;
        }

        public GameStateBinder BindState<TState>()
            where TState : class, IRunnableState
        {
            container.BindInterfacesAndSelfTo<TState>().AsCached();
            return this;
        }

    }
}