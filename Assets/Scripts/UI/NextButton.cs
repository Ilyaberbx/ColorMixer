using ColorMixer.Data;
using ColorMixer.Interfaces;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ColorMixer.UI
{
    public class NextButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private DOTweenUISettings _settings;
        private ISceneLoader _sceneLoader;
        public void Initialize(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _button.onClick.AddListener(NextLevel);
        }
        private void NextLevel()
        {
            var sequence = DOTween.Sequence();
            sequence.Append(PunchButton());
            sequence.AppendCallback(_sceneLoader.NextLevel);
        }
        private Tween PunchButton()
        {
            Vector3 punchScale = _button.transform.localScale * _settings.ScaleCoefficient;
            return _button.transform.DOPunchScale(punchScale, _settings.AnimationsDuration);
        }
    }
}
