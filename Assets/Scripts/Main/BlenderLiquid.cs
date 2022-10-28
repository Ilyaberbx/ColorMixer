using UnityEngine;
using DG.Tweening;
using ColorMixer.Interfaces;

namespace ColorMixer
{
    [RequireComponent(typeof(MeshRenderer))]
    public class BlenderLiquid : MonoBehaviour
    {
        private ITweenSettings _settings;

        public void Initialize(ITweenSettings settings) => _settings = settings;

        public Tween Appear()
        {
            Vector3 prevScale = transform.localScale;
            transform.localScale = Vector3.zero;
            return transform.DOScale(prevScale, _settings.AnimationsDuration);
        }

    }
}
