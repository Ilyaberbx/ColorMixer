using ColorMixer.States;
using ColorMixer.Interfaces;
using ColorMixer.UI;

namespace ColorMixer.Factories
{
    public class GameStatesFactory : IStateFactory
    {
        private GamePlayHud _gamePlayHud;
        private GameWinHud _gameWinHud;
        private GameOverHud _gameOverHud;
        public GameStatesFactory(GamePlayHud gamePlayHud, GameWinHud gameWinHud, GameOverHud gameOverHud)
        {
            _gamePlayHud = gamePlayHud;
            _gameWinHud = gameWinHud;
            _gameOverHud = gameOverHud;
        }
        public GameOverState CreateGameOverState() => new GameOverState(_gameOverHud);
        public GameWinState CreateGameWinState() => new GameWinState(_gameWinHud);
        public GamePlayState CreateGamePlayState() => new GamePlayState(_gamePlayHud);
    }
}
