using DG.Tweening;
using System;
using UnityEngine;
using ColorMixer.Storages;
using ColorMixer.Interfaces;

namespace ColorMixer.Interactions
{
    public class FoodInteractWithBlender
    {
        public Action OnInteractionEnded;
        public Action<FoodItem> OnFoodGetted;

        private Sequence _sequence;
        private Cap _cap;
        private Blender _blender;
        private ITweenSettings _settings;
        private Transform _transform;
        private SequncesStorage _sequnceStorage;
        private MixerStorage _mixerStorage;
        public FoodInteractWithBlender(Cap cap, Blender blender, ITweenSettings settings,SequncesStorage sequncesStorage)
        {
            _cap = cap;
            _blender = blender;
            _settings = settings;
            _sequnceStorage = sequncesStorage;
        }
        public void Execute(Transform transform)
        {        
            _transform = transform;
            _sequnceStorage.AddSequnce(_sequence = DOTween.Sequence());
            _sequence.Append(_cap.Open());
            _sequence.Append(ThrowFood());
            _sequence.Append(DecreaseFoodObjectSize());
            _sequence.Append(_blender.Shake());
            _sequence.AppendCallback(CheckTweens);
            _sequence.AppendCallback(InvokeEvents);
            _sequence.Append(_cap.Close());
            _sequence.AppendCallback(RemoveCurrentSequnce);
        }
        private Tween ThrowFood() => _transform.DOJump(_blender.transform.position, _settings.AnimationsJumpPower, 1, _settings.AnimationsDuration);
        private Tween DecreaseFoodObjectSize() => _transform.DOScale(new Vector3(_transform.localScale.x / 1.5f , _transform.localScale.x / 1.5f, _transform.localScale.x / 1.5f), _settings.AnimationsDuration);
        private void InvokeEvents()
        {
            OnFoodGetted?.Invoke(_transform.GetComponent<FoodItem>());
            OnInteractionEnded?.Invoke();
        }
        private void CheckTweens()
        { 
            if(_sequnceStorage.GetSequncesCount() != 1)
            {
                InvokeEvents();
                RemoveCurrentSequnce();
                _sequence.Kill();
            }
        }
        private void RemoveCurrentSequnce() => _sequnceStorage.RemoveSequnce(_sequence);

    }
}