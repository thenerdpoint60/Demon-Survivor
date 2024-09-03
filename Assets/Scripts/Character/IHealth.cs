namespace DemonSurvivor
{
    public interface IHealth
    {
        public void Heal(int health);

        public void Damage(int damage);

        public bool HasDied();
    }
}