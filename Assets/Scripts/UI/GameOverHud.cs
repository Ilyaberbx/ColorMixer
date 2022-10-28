using ColorMixer.Decorator;
using UnityEngine;
using DG.Tweening;

namespace ColorMixer.UI
{
    public class GameOverHud : GameExodusHudDecorator
    {
        [SerializeField] private RestartButton _restartButton;

        public override void Open()
        {
            base.Open();
            ShowRestartButton();
        }
        private void ShowRestartButton()
        {
            _sequence.AppendCallback(ShowButton);
            _sequence.Append(PunchItem(_restartButton.transform));
        }
        private void ShowButton() => ShowItem(_restartButton.transform);
    }
}
