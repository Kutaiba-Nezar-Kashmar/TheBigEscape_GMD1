namespace Weapons.Model
{
    public interface IFireInput
    {
        delegate void FireInput();
        event FireInput OnFire;
    }
}