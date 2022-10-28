using UnityEngine;
using ColorMixer.Interfaces;
namespace ColorMixer.Data
{
    [CreateAssetMenu(menuName = "ColorMixer/DOTweenSettings")]
    public class DOTweenSettings : ScriptableObject,ITweenSettings
    {
        [SerializeField] private float _animationsDuration;
        [SerializeField] private float _animationsJumpPower;
        public float AnimationsDuration => _animationsDuration;
        public float AnimationsJumpPower => _animationsJumpPower;
    }
}