using DG.Tweening;
using UnityEngine;

namespace ColorMixer.ObjectPool
{
    public class FoodItemsPool : MonoBehaviour
    {
        public PoolMono<FoodItem> Pool { get; private set; }
        [SerializeField] private int _capacity;
        [SerializeField] private FoodItem _prefab;
        [SerializeField] private Transform _container;

        public void Initialize() => Pool = new PoolMono<FoodItem>(_prefab, _capacity, true,_container);

        public FoodItem GetElement() => Pool.GetFreeElement();

        public void Clear()
        {
            Sequence sequnce = DOTween.Sequence();

            foreach (var item in Pool.ActivePool)
            {
                if(item.gameObject.activeInHierarchy)
                sequnce.Append(item.Disappear());
            }
            sequnce.AppendCallback(Pool.Clear);
        }
    } 
}
