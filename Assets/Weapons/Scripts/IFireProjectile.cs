using UnityEngine;

namespace Weapons.Scripts
{
    public interface IFireProjectile
    {
        void FireProjectile(Vector3 direction, float fireRate);
    }
}