using UnityEngine;
using ColorMixer.Interfaces;
using UnityEngine.UI;
using DG.Tweening;
using ColorMixer.Data;

namespace ColorMixer.UI
{
    public class RestartButton : MonoBehaviour
    {
        [SerializeField] private DOTweenUISettings _settings;
        [SerializeField] private Button _button;
        private ISceneLoader _sceneLoader;
        public void Initialize(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _button.onClick.AddListener(Restart);
        }
        private void Restart()
        {
            var sequence = DOTween.Sequence();
            sequence.Append(PunchButton());
            sequence.AppendCallback(_sceneLoader.Restart);
        }
        private Tween PunchButton()
        {
            Vector3 punchScale = _button.transform.localScale * _settings.ScaleCoefficient;
            return _button.transform.DOPunchScale(punchScale, _settings.AnimationsDuration);
        }

    }
}
