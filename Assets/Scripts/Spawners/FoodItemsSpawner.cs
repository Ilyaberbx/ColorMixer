using UnityEngine;
using ColorMixer.ObjectPool;
using ColorMixer.Storages;
using ColorMixer.Interfaces;
using ColorMixer.Interactions;

namespace ColorMixer
{
    public class FoodItemsSpawner : MonoBehaviour
    {
        [SerializeField] private FoodItemsPool _pool;
        [SerializeField] private Transform _spawnPoint;
        private Cap _cap;
        private Blender _blender;
        private ITweenSettings _settings;
        private SequncesStorage _sequnceStorage;
        private MixerStorage _mixerStorage;
        public void Initialize(Cap cap , Blender blender, ITweenSettings settings,SequncesStorage sequenceStorage,MixerStorage mixerStorage)
        {
            _cap = cap;
            _blender = blender;
            _settings = settings;
            _sequnceStorage = sequenceStorage;
            _mixerStorage = mixerStorage;
            Spawn();
        }
        private void Spawn()
        {
            FoodItem foodItem =_pool.GetElement();
            InitializeSpawnedItem(foodItem);
        }
        private void InitializeSpawnedItem(FoodItem foodItem)
        {
            foodItem.gameObject.SetActive(true);
            foodItem.transform.position = _spawnPoint.position;
            foodItem.Initialize(_settings);
            FoodItemInteractor foodInteractor = foodItem.GetComponent<FoodItemInteractor>();
            foodInteractor.Initialize(_cap, _blender, _sequnceStorage, _settings);
            foodInteractor.InteractWithBlender.OnFoodGetted += _mixerStorage.AddFood;
            foodInteractor.InteractWithBlender.OnInteractionEnded += Spawn;
        }

    }
}
