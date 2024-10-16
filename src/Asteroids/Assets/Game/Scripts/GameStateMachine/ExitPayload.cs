namespace com.asteroids.scripts.StateMachine.Game.Scripts.GameStateMachine
{
    public class ExitPayload : IPayload
    {
        public bool IsNull { get; set; }
        public IPayload Payload;
        
        public ExitPayload(IPayload payload, bool empty = true)
        {
            IsNull = empty;
            Payload = payload;
        }
    }
}