using UnityEngine;
using ColorMixer.Storages;
using DG.Tweening;
using System;
using ColorMixer.StateMachines;
using ColorMixer.Static;

namespace ColorMixer
{
    public class Mixer
    {
        public Action<Color> OnMixed;

        private const float ShakingStrenght = 0.7f;
        private const int ShakingLenght = 1;

        private Blender _blender;
        private BlenderLiquid _blenderLiquid;
        private MeshRenderer _blendObjMeshRenderer;
        private MixerStorage _storage;
        private Material _mixMaterial;
        private GameStateMachine _stateMachine;

        private bool _isMixed;
        private Color _mixedColor;

        public Mixer(MixerStorage storage, BlenderLiquid blenderLiquid, Blender blender, Material materialToMix, GameStateMachine stateMachine)
        {
            _storage = storage;
            _blenderLiquid = blenderLiquid;
            _blender = blender;
            _stateMachine = stateMachine;
            _blenderLiquid.TryGetComponent(out _blendObjMeshRenderer);

            if (_blendObjMeshRenderer != null)
                _blendObjMeshRenderer.material = null;

            _blenderLiquid.gameObject.SetActive(false);

            _mixMaterial = materialToMix;
        }

        public void Mix()
        {
            if (_storage.GetFoodCount() == 0)
            {
                _stateMachine.SetGameOverState();
                return;
            }
            if (_isMixed) return;

            _isMixed = true;
            MixingSequnce();
            _storage.ClearMixer();

        }
        private void MixingSequnce()
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(_blender.Shake(ShakingStrenght, ShakingLenght));
            sequence.AppendCallback(CalculateMaterialColor);
            sequence.Append(EmergenceLiquid());
            sequence.AppendCallback(InvokeCallBack);
        }
        private void CalculateMaterialColor()
        {
            _mixedColor = Color.white;
            _mixedColor = ColorCalculator.CalculateColorFromItemsList(_storage.GetFood());
            _mixMaterial.color = _mixedColor;
            _blendObjMeshRenderer.material = _mixMaterial;
        }
        private Tween EmergenceLiquid()
        {
            _blenderLiquid.gameObject.SetActive(true);
            return _blenderLiquid.Appear();
        }
        private void InvokeCallBack() => OnMixed?.Invoke(_mixedColor);
    }
}
