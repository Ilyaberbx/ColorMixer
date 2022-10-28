using UnityEngine;
using ColorMixer.Interactions;
using DG.Tweening;
using ColorMixer.Interfaces;

namespace ColorMixer
{
    [RequireComponent(typeof(FoodItemInteractor))]
    public class FoodItem : MonoBehaviour
    {
        [SerializeField] private Color _color;
        private ITweenSettings _settings;

        public void Initialize(ITweenSettings settings)
        {
            _settings = settings;
            Appear();
        }
        public Color GetItemColor() => _color;

        private void Appear()
        {
            Vector3 prevScale = transform.localScale;
            transform.localScale = Vector3.zero;
            transform.DOScale(prevScale, _settings.AnimationsDuration);            
        }
        public Tween Disappear() => transform.DOScale(Vector3.zero, _settings.AnimationsDuration);

    }
}
