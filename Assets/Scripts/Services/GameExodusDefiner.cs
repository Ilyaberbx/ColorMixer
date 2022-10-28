using ColorMixer.StateMachines;
using UnityEngine;

namespace ColorMixer.GameExodus
{
    public class GameExodusDefiner
    {
        private int _similarityPercentToWin;

        private GameStateMachine _stateMachine;

        public GameExodusDefiner(GameStateMachine gameStateMachine, int similarityPercentToWin)
        {
            _similarityPercentToWin = similarityPercentToWin;
            _stateMachine = gameStateMachine;
        }

        public void DefineExodus(int similarityPercent)
        {
            Debug.Log(similarityPercent);

            if (similarityPercent < _similarityPercentToWin)
            {
                Lose();
                return;
            }

            Win();
        }
        private void Win() => _stateMachine.SetGameWinState();
        private void Lose() => _stateMachine.SetGameOverState();
    }
}
