using ColorMixer.Data;
using ColorMixer.Interfaces;
using ColorMixer.UI;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ColorMixer.Decorator
{
    public abstract class GameExodusHudDecorator : MonoBehaviour, IHud
    {
        [SerializeField] private CanvasGroup _canvas;
        [SerializeField] private DOTweenUISettings _settings;
        [SerializeField] private Image _inscription;
        [SerializeField] private Image _mark;
        [SerializeField] private TextMeshProUGUI _similarityText;

        private SimilarityCounter _similarityCounter;
        protected Sequence _sequence;


        public void Initialize(SimilarityCounter similairityCounter)
        {
            _similarityCounter = similairityCounter;
            _canvas.gameObject.SetActive(false);
            _inscription.gameObject.SetActive(false);
            _mark.gameObject.SetActive(false);
            _similarityText.gameObject.SetActive(false);
        }

        public virtual void Open()
        {
            _canvas.gameObject.SetActive(true);
            _sequence = DOTween.Sequence();
            _sequence.Append(_canvas.DOFade(1, _settings.AnimationsDuration - _settings.AppearenceOffSet)
                .From(0));
            _sequence.AppendCallback(ShowInscription);
            _sequence.Append(PunchInscription());
            _sequence.AppendCallback(ShowMark);
            _sequence.Append(PunchMark());
            _sequence.AppendCallback(ShowText);
            _sequence.Append(PunchText());
            _sequence.AppendCallback(ShowSimilarity);
        }

        public void Close()
        {
            _canvas.gameObject.SetActive(false);
            var sequnce = DOTween.Sequence();
            sequnce.Append(_canvas.DOFade(0, _settings.AnimationsDuration - _settings.AppearenceOffSet)
                .From(1));
        }   
        private void ShowSimilarity() => StartCoroutine(_similarityCounter.ShowSimilarityRoutine(_similarityText));
        private Tween PunchInscription() => PunchItem(_inscription.transform);
        private Tween PunchText() => PunchItem(_similarityText.transform);
        private Tween PunchMark() => PunchItem(_mark.transform);
        private void ShowInscription() => ShowItem(_inscription.transform);
        private void ShowText() => ShowItem(_similarityText.transform);
        private void ShowMark() => ShowItem(_mark.transform);
        protected Tween PunchItem(Transform transform)
        {
            Vector3 punchScale = transform.localScale * _settings.ScaleCoefficient;
            return transform.DOPunchScale(punchScale, _settings.AnimationsDuration - _settings.AppearenceOffSet);
        }
        protected void ShowItem(Transform transform) => transform.gameObject.SetActive(true);

    }
}
