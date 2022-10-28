using System;
using System.Collections.Generic;
using ColorMixer.Interfaces;
using ColorMixer.Factories;
using ColorMixer.States;

namespace ColorMixer.StateMachines
{
    public class GameStateMachine
    {
        private Dictionary<Type, IState> _statesMap = new Dictionary<Type, IState>();

        private IState _currentState;

        public GameStateMachine(IStateFactory statesFactory)
        {      
            _statesMap[typeof(GameOverState)] = statesFactory.CreateGameOverState();
            _statesMap[typeof(GamePlayState)] = statesFactory.CreateGamePlayState();
            _statesMap[typeof(GameWinState)] = statesFactory.CreateGameWinState();
            SetGamePlayState();
        }

        public void SetGamePlayState() => SetState(GetState<GamePlayState>());
        public void SetGameWinState() => SetState(GetState<GameWinState>());
        public void SetGameOverState() => SetState(GetState<GameOverState>());

        private void SetState(IState state)
        {
            if (_currentState != null)
                _currentState.Exit();

            _currentState = state;
            _currentState.Enter();
        }
        private IState GetState<T>() where T : IState
        {
            var type = typeof(T);
            return _statesMap[type];
        }

    }
}
