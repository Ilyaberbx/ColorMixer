using System;
using UnityEngine;

namespace ColorMixer.MainMechanic
{
    public class ColorComparisoner 
    {
        private const int OffSetToMoreCasual = 20;

        public Action<int> OnCompared;

        private Color _desiredColor;

        public ColorComparisoner(Color color) => _desiredColor = color;
        public void CompareColor(Color color)
        {
            var r = CalculateSimilarityPercentToSimpleValue(_desiredColor.r, color.r);
            var g = CalculateSimilarityPercentToSimpleValue(_desiredColor.g, color.g);
            var b = CalculateSimilarityPercentToSimpleValue(_desiredColor.b, color.b);

            var result = (r + g + b) / 3;

            MakeMoreCasual(ref result);          
            OnCompared?.Invoke(result);
        }
        private int CalculateSimilarityPercentToSimpleValue(float a, float b)
        {
            float valueToPercent  = a - b;
            return Mathf.RoundToInt(((1 - Mathf.Abs(valueToPercent)) * 100));
        }
        private void MakeMoreCasual(ref int value)
        {
            if (value <= 90)
                value -= OffSetToMoreCasual;
            else
                value = 100;
        }
    }
}
