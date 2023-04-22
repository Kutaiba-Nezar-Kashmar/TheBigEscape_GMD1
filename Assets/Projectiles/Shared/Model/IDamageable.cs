namespace Projectiles.Shared.Scripts
{
    public interface IDamageable
    {
        /// <summary>
        /// Objects hit points
        /// </summary>
        public int HitPoint { get; set; }
        
        /// <summary>
        /// Retrieving the damage from a projectile  
        /// </summary>
        /// <param name="damage">Amount of damage taken</param>
        public void ReceivedDamage(int damage);
    }
}