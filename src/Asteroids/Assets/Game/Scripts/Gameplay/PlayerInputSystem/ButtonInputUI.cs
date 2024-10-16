using com.asteroids.scripts.Gameplay.Game.Scripts.Gameplay.PlayerInputSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace asteroids.scripts
{
    public class ButtonInputUI : MonoBehaviour ,IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, ISubmitHandler
    {
        public InputAction InputAction;
        public InputType InputType;
        
        private InputSystemProvider inputSystemProvider;

        [Inject]
        internal void Construct(InputSystemProvider inputSystemProvider)
        {
            this.inputSystemProvider = inputSystemProvider;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            inputSystemProvider.PushEvent(InputAction,true, InputType);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            inputSystemProvider.PushEvent(InputAction,false, InputType);
        }

        
        public void OnPointerClick(PointerEventData eventData)
        {
         //   inputSystemProvider.PushEvent(InputAction,true, InputType);
        }

        public void OnSubmit(BaseEventData eventData)
        {
        //    inputSystemProvider.PushEvent(InputAction,true, InputType);
        }
    }

 
}
