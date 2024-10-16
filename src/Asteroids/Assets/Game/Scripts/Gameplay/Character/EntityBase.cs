using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace com.asteroids.scripts.Gameplay
{
    public abstract class EntityBase : MonoBehaviour, IHittable
    {
        public event Action OnDeath;
        public event Action OnKill;


        protected ObjectPool<EntityBase> Pool;
        protected List<ICharacterComponent> CharacterComponents;


        protected virtual void Start()
        {
            foreach (var component in CharacterComponents)
                component.Start();
        }

        protected virtual void FixedUpdate()
        {
            foreach (var component in CharacterComponents)
                component.FixedUpdate();
        }

        protected virtual void Update()
        {
            foreach (var component in CharacterComponents)
                component.Update();
        }

        public virtual void Hit(GameObject source)
        {
            Death();
        }

        public virtual void Death()
        {
            foreach (var characterComponent in CharacterComponents)
                characterComponent.OnDamage();

            Pool?.Release(this);
            OnDeath?.Invoke();
        }


        public void SetPool(ObjectPool<EntityBase> pool)
        {
            Pool = pool;
        }

        protected void CallOnDeath()
        {
            foreach (var characterComponent in CharacterComponents)
                characterComponent.OnDamage();
            OnDeath?.Invoke();
        }

        protected void CallOnKill()
        {
            foreach (var characterComponent in CharacterComponents)
                characterComponent.OnHitEnemy();
            OnKill?.Invoke();
        }
    }
}