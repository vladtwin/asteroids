using System.Collections.Generic;
using Zenject;

namespace com.asteroids.scripts.StateMachine.Game.Scripts.GameStateMachine
{
    public class ApplicationStateMachine : BaseStateMachine
    {
        [Inject]
        public ApplicationStateMachine( DiContainer container) : base(container)
        {
        }
    }
}