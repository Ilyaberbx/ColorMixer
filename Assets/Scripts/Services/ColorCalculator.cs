using System.Collections.Generic;
using UnityEngine;

namespace ColorMixer.Static
{
    public static class ColorCalculator
    {
        public static Color CalculateColorFromItemsList(List<FoodItem> items)
        {
            Color color = Color.white;
            foreach (var item in items)
            {
                color.r += item.GetItemColor().r;
                color.g += item.GetItemColor().g;
                color.b += item.GetItemColor().b;
            }
            color.r = Mathf.Clamp(color.r /= items.Count, 0, 1);
            color.g = Mathf.Clamp(color.g /= items.Count, 0, 1);
            color.b = Mathf.Clamp(color.b /= items.Count, 0, 1);

            return color;
        }
    }
}
