namespace Projectiles.Shared.Scripts
{
    public interface IDamageable
    {
        /// <summary>
        /// Retrieving the damage from a projectile  
        /// </summary>
        /// <param name="damage">Amount of damage taken</param>
        public void ReceivedDamage(int damage);
    }
}