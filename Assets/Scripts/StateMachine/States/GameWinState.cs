using ColorMixer.Interfaces;

namespace ColorMixer.States
{
    public class GameWinState : IState
    {
        private IHud _gameWinHud;
        public GameWinState(IHud gameWinHud)
        {
            _gameWinHud = gameWinHud;
        }
        public void Enter()
        {
            _gameWinHud.Open();
        }

        public void Exit()
        {
            _gameWinHud.Close();
        }
    }
}
