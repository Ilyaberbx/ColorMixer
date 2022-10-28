using System;
using UnityEngine;

namespace ColorMixer
{
    public class MixerButton : MonoBehaviour
    {
        public Action OnMixButtonTapped;
        private void OnMouseDown()
        {
            OnMixButtonTapped?.Invoke();
        }
    }
}

