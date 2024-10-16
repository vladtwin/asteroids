using System;

namespace com.asteroids.scripts.StateMachine.Game.Scripts.GameStateMachine
{
    public class StateMachineException : ApplicationException
    {
        public StateMachineException(string message) : base(message) {}
    }
}