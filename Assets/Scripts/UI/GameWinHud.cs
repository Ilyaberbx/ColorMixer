using ColorMixer.Decorator;
using UnityEngine;
using DG.Tweening;

namespace ColorMixer.UI
{
    public class GameWinHud : GameExodusHudDecorator
    {
        [SerializeField] private NextButton _nextButton;

        public override void Open()
        {
            base.Open();
            ShowNextButton();
        }
        private void ShowNextButton()
        {
            _sequence.AppendCallback(ShowButton);
            _sequence.Append(PunchItem(_nextButton.transform));
        }
        private void ShowButton() => ShowItem(_nextButton.transform);
    }
}
