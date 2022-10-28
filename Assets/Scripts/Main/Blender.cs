
using DG.Tweening;
using UnityEngine;
using ColorMixer.Data;
using ColorMixer.Interfaces;

namespace ColorMixer
{
    public class Blender : MonoBehaviour
    {
        private ITweenSettings _settings;
        public void Initialize(ITweenSettings settings) => _settings = settings;
        public Tween Shake(float strenght = 0.3f,float lenght = 0) => transform.DOShakeScale(_settings.AnimationsDuration + lenght, strenght);
    }
}
