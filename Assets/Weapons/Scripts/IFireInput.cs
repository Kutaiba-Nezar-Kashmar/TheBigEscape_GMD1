namespace Weapons.Scripts
{
    public interface IFireInput
    {
        delegate void FireInput();
        event FireInput OnFire;
    }
}