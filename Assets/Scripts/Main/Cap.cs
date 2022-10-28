using UnityEngine;
using DG.Tweening;
using ColorMixer.Interfaces;

namespace ColorMixer
{
    public class Cap : MonoBehaviour
    {
        private ITweenSettings _settings;

        public void Initialize(ITweenSettings settings) => _settings = settings;

        public Tween Open() => RotateCap(-90);

        public Tween Close() => RotateCap(0);
        private Tween RotateCap(int angle) => transform.DOLocalRotate(new Vector3(angle, 0, 0), _settings.AnimationsDuration, RotateMode.Fast);
    }
}
