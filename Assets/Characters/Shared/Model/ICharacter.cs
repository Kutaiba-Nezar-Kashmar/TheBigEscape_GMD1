namespace Characters.Shared.Model
{
    public interface ICharacter
    {
        bool IsMoving { get; set; }
        bool IsRunning { get; set; }
    }
}