namespace Weapons.Model
{
    public interface IWeapon
    {
        void ShootWeapon();
        void ReloadWeapon();

        int FetchWeaponMagSize();
    }
}