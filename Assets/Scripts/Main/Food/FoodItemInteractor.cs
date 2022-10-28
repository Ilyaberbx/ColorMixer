using ColorMixer.Interfaces;
using ColorMixer.Storages;
using System;
using UnityEngine;

namespace ColorMixer.Interactions
{
    [RequireComponent(typeof(BoxCollider))]
    public class FoodItemInteractor : MonoBehaviour
    {
        public FoodInteractWithBlender InteractWithBlender { get; private set; }
        private bool _tapped;
        public void Initialize(Cap cap, Blender blender, SequncesStorage sequenceStorage, ITweenSettings settings) => InteractWithBlender = new FoodInteractWithBlender(cap, blender, settings, sequenceStorage);
        private void OnMouseDown()
        {
            if(!_tapped)
            {
                _tapped = true;
                InteractWithBlender.Execute(transform);
            }
        }
    }
}
