using ColorMixer.Interfaces;

namespace ColorMixer.States
{
    public class GamePlayState : IState
    {
        private IHud _gamePlayHub;
        public GamePlayState(IHud gamePlayHud)
        {
            _gamePlayHub = gamePlayHud;
        }

        public void Enter()
        {
            _gamePlayHub.Open();
        }

        public void Exit()
        {
            _gamePlayHub.Close();
        }
    }
}
