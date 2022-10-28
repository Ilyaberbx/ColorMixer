using ColorMixer.Interfaces;

namespace ColorMixer.States
{
    public class GameOverState : IState
    {
        private IHud _gameOverHud;
        public GameOverState(IHud gameOverHud)
        {
            _gameOverHud = gameOverHud;
        }
        public void Enter()
        {
            _gameOverHud.Open();
        }

        public void Exit()
        {
            _gameOverHud.Close();
        }
    }
}
