namespace Weapons.Model
{
    public interface IReloadInput
    {
        delegate void ReloadInput();
        event ReloadInput OnReload;
    }
}