using UnityEngine;

namespace ColorMixer.Data
{
    [CreateAssetMenu(menuName = "ColorMixer/DOTweenUISettings")]
    public class DOTweenUISettings : ScriptableObject
    {
        [SerializeField] private float _animationsDuration;
        [SerializeField] private float _scaleCoefficient;
        [SerializeField] private float _appearcenceOffSet;
        public float AnimationsDuration => _animationsDuration;
        public float ScaleCoefficient => _scaleCoefficient;
        public float AppearenceOffSet => _appearcenceOffSet;
    }
}
