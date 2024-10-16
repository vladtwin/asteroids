using System.Collections.Generic;

namespace com.asteroids.scripts.Gameplay.Game.Scripts.Gameplay.PlayerInputSystem
{
    internal class InputSystemProvider
    {
        
        private Dictionary<InputAction, ButtonEventData> events = new Dictionary<InputAction, ButtonEventData>();

        public void PushEvent(InputAction eventType, bool value, InputType inputType)
        {
            events[eventType] = new ButtonEventData(){InputType = inputType, Pressed = value};
        }

        public bool PopEvent(InputAction eventType)
        {
            if (events.ContainsKey(eventType))
            {
                if (events[eventType].InputType == InputType.Once && events[eventType].Pressed)
                {
                    events[eventType] = new ButtonEventData(){InputType = InputType.Once , Pressed = false};
                    return true;
                }
                return events[eventType].Pressed;
            }
            return false;
        }
        
    }
}