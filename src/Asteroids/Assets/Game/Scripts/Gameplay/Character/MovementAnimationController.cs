using UnityEngine;

namespace com.asteroids.scripts.Gameplay
{
    public class MovementAnimationController : ICharacterComponent
    {
        private ICharacterMovement movementComponent;
        private Animator animator;
        private bool enabled = true;
        public MovementAnimationController(ICharacterMovement movementComponent, Animator animator)
        {
            this.movementComponent = movementComponent;
            this.animator = animator;
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            // animator file is readonly, required to modify at Aseprite 
            // animator.SetBool("moving",movementComponent.Speed > 0.1f);

            if (enabled != movementComponent.Speed > 0.1f)
            {
                enabled = !enabled;

                if (enabled)
                {
                    animator.StopPlayback();
                }
                else
                {
                    animator.Rebind();
                    animator.StartPlayback();

                }
            }
            
        }

        public void FixedUpdate()
        {
        }

        public void Restart()
        {
            
        }

        public void OnDamage()
        {
            
        }

        public void OnHitEnemy()
        {
        }
    }
}