namespace Characters.Player.Model
{
    public interface IPauseInput
    {
        delegate void PauseInput();
        event PauseInput OnPause;
    }
}