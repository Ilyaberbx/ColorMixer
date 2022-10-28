using UnityEngine;
using ColorMixer.Interfaces;
using ColorMixer.Data;
using UnityEngine.UI;
using DG.Tweening;

namespace ColorMixer.UI
{
    public class GamePlayHud : MonoBehaviour, IHud
    {
        [SerializeField] private DOTweenUISettings _settings;
        [SerializeField] private Image _cloudWindow;
        [SerializeField] private CanvasGroup _canvas;

        public void Open()
        {
            _canvas.gameObject.SetActive(true);
            var sequnce = DOTween.Sequence();
            sequnce.Append(_canvas.DOFade(1, _settings.AnimationsDuration - _settings.AppearenceOffSet)
                .From(0));
            sequnce.Append(ShowCloud());
        }
        public void Close()
        {
            _canvas.gameObject.SetActive(false);
            var sequnce = DOTween.Sequence();
            sequnce.Append(_canvas.DOFade(0, _settings.AnimationsDuration - _settings.AppearenceOffSet)
                .From(1));
        }
        private Tween ShowCloud()
        {
            Vector3 punchScale = _cloudWindow.transform.localScale * _settings.ScaleCoefficient;
           return _cloudWindow.transform.DOPunchScale(punchScale, _settings.AnimationsDuration);
        }


    }
}
