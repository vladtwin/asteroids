using System;
using com.asteroids.scripts.Gameplay.Game.Scripts.Gameplay.PlayerInputSystem;
using UnityEngine;
using UnityEngine.UI;

namespace com.asteroids.scripts.Gameplay
{
    public class CharacterMovement : ICharacterComponent, ICharacterMovement
    {
        public float Speed => currentSpeed;

        private IPlayerInputSystem input;
        private IPlayerShipSettings settings;
        private Transform transform;

        private float movementTime = 0f;
        private float nitroTime = 0f;
        private float freeMovementTime = 0f;
        private float currentSpeed = 0;
        private Vector3 velocity;
        private Rigidbody2D rigidbody2D;

        public CharacterMovement(IPlayerInputSystem input, IPlayerShipSettings settings, Transform transform)
        {
            this.settings = settings;
            this.transform = transform;
            this.input = input;
        }

        public void Start()
        {
            rigidbody2D = transform.GetComponent<Rigidbody2D>();
        }

        public void Update()
        {
        }

        public void FixedUpdate()
        {
            // var horizontal = Math.Sign(Input.GetAxis("Horizontal"));
            //  var vertical = Input.GetAxis("Vertical") > 0 ? 1 : 0;
            //  var isNitro = Input.GetButton("Jump");

            var moveVector = input.MoveVector();
            var horizontal = moveVector.x;
            var vertical = moveVector.y;
            var isNitro = input.IsNitro();
            
            var isMoving = vertical != 0 || horizontal != 0;
            var rotationAmount = 0f;

            if (isMoving)
            {
                currentSpeed = CalculateSpeed(true, isNitro);
                velocity =  this.transform.right * currentSpeed * Time.deltaTime;
                freeMovementTime = settings.FreeMoveTime;
            }
            else
            {
                freeMovementTime -= Time.deltaTime;
                currentSpeed = CalculateSpeed(freeMovementTime > 0, isNitro);
                velocity = this.transform.right * currentSpeed * Time.deltaTime;
            }
            
            this.transform.position += velocity;

           // rigidbody2D.velocity = velocity * 40;
            rotationAmount = settings.RotationSpeed * Time.deltaTime * -horizontal;
            this.transform.rotation =
                Quaternion.Euler(0, 0, this.transform.rotation.eulerAngles.z + rotationAmount);
        }

        public void Restart()
        {
        }

        public void OnDamage()
        {
            movementTime = 0f;
            nitroTime = 0f;
            freeMovementTime = 0f;
            currentSpeed = 0;
            velocity = Vector2.zero;
        }

        public void OnHitEnemy()
        {
        }

        private float CalculateSpeed(bool isMoving, bool isNitro)
        {
            CalculateMovementTime(ref movementTime, isMoving, settings.TimeToMaxSpeed);
            CalculateMovementTime(ref nitroTime, isNitro, settings.TimeToMaxSpeedNitro);

            var normalSpeed = settings.VelocityCurve.Evaluate(movementTime / settings.TimeToMaxSpeed) *
                              settings.MaxMoveSpeed;

            var additionalSpeed = settings.NitroVelocityCurve.Evaluate(nitroTime / settings.TimeToMaxSpeedNitro) *
                                  settings.MaxNitroMoveSpeed;
            return normalSpeed + additionalSpeed;
        }


        private void CalculateMovementTime(ref float movementTime, bool isMoving, float timeToMaxSpeed)
        {
            if (isMoving)
            {
                if (movementTime >= timeToMaxSpeed)
                    movementTime = timeToMaxSpeed;
                else
                {
                    movementTime += Time.deltaTime;
                }
            }
            else
            {
                if (movementTime > 0)
                    movementTime -= Time.deltaTime;
            }
        }
    }
}