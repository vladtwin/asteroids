namespace com.asteroids.scripts.Gameplay
{
    public interface ICharacterComponent
    {
        public void Start();
        public void Update();
        public void FixedUpdate();
        public void Restart();
        public void OnDamage();
        public void OnHitEnemy();
    }
}