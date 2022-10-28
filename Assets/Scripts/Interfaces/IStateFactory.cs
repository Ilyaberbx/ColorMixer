using ColorMixer.States;

namespace ColorMixer.Interfaces
{
    public interface IStateFactory
    {
        GameOverState CreateGameOverState();
        GameWinState CreateGameWinState();
        GamePlayState CreateGamePlayState();
    }
}
