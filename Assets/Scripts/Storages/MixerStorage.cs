using System.Collections.Generic;

namespace ColorMixer.Storages
{
    public class MixerStorage
    {
        private List<FoodItem> _itemsToMix = new List<FoodItem>();

        public void AddFood(FoodItem item)
        {
            if (item != null)
                _itemsToMix.Add(item);          
        }
        public List<FoodItem> GetFood() => _itemsToMix;
        public int GetFoodCount() => _itemsToMix.Count;

        public void ClearMixer()
        {
            foreach (var item in _itemsToMix)
            {
                item.gameObject.SetActive(false);
            }
        }
    }
}
