using UnityEngine;
using ColorMixer.StateMachines;
using ColorMixer.Factories;
using ColorMixer.Data;
using System.Collections.Generic;
using ColorMixer.ObjectPool;
using ColorMixer.Storages;
using ColorMixer.MainMechanic;
using ColorMixer.GameExodus;
using ColorMixer.UI;
using ColorMixer.Scene;
using ColorMixer.Static;

namespace ColorMixer.BootStrap
{
    public class BootStrap : MonoBehaviour
    {
        [Header("Generic")]
        [SerializeField] private BlenderLiquid _blenderLiquid;
        [SerializeField] private Material _materialToMix;
        [SerializeField] private MixerButton _mixerButton;
        [SerializeField] private Cap _cap;
        [SerializeField] private Blender _blender;

        [Header("Config")]
        [SerializeField] private DOTweenSettings _settings;

        [Header("Pools and Spawners")]
        [SerializeField] private List<FoodItemsPool> _pools;
        [SerializeField] private List<FoodItemsSpawner> _spawners;

        [Header("UI")]
        [SerializeField] private GamePlayHud _gamePlayHud;
        [SerializeField] private GameWinHud _gameWinHud;
        [SerializeField] private GameOverHud _gameOverHud;
        [SerializeField] private RestartButton _restartButton;
        [SerializeField] private NextButton _nextButton;

        [Header("LevelParams")]
        [SerializeField] private int _similarityPercantToWin;
        [SerializeField] private float _similarityShowingSpeed;
        [SerializeField] private List<FoodItem> _foodItemsNeededToMix;

        private GameStateMachine _gameStateMachine;
        private GameStatesFactory _gameStatesFactory;
        private SequncesStorage _sequnceStorage;
        private MixerStorage _mixerStorage;
        private Mixer _mixer;
        private ColorComparisoner _colorComparison;
        private GameExodusDefiner _gameExodusDefiner;
        private SimilarityCounter _similarityCounter;
        private SceneLoader _sceneLoader;
        private Color _desiredColor;

        private void Awake()
        {
            _desiredColor = ColorCalculator.CalculateColorFromItemsList(_foodItemsNeededToMix);          
            _gameStatesFactory = new GameStatesFactory(_gamePlayHud,_gameWinHud,_gameOverHud);
            _gameStateMachine = new GameStateMachine(_gameStatesFactory); 
            _sequnceStorage = new SequncesStorage();
            _mixerStorage = new MixerStorage();
            _mixer = new Mixer(_mixerStorage, _blenderLiquid, _blender, _materialToMix,_gameStateMachine);
            _colorComparison = new ColorComparisoner(_desiredColor);
            _gameExodusDefiner = new GameExodusDefiner(_gameStateMachine, _similarityPercantToWin);
            _similarityCounter = new SimilarityCounter(_similarityShowingSpeed);
            _sceneLoader = new SceneLoader();


            _restartButton.Initialize(_sceneLoader);
            _nextButton.Initialize(_sceneLoader);
            _blenderLiquid.Initialize(_settings);

            _gameOverHud.Initialize(_similarityCounter);
            _gameWinHud.Initialize(_similarityCounter);
            _cap.Initialize(_settings);
            _blender.Initialize(_settings);
            foreach (var pool in _pools)
                pool.Initialize();
            foreach (var spawner in _spawners)
                spawner.Initialize(_cap,_blender,_settings, _sequnceStorage, _mixerStorage);
            
         
            _mixerButton.OnMixButtonTapped += _mixer.Mix;
            foreach (var pool in _pools)
                _mixerButton.OnMixButtonTapped += pool.Clear;

            _mixer.OnMixed += _colorComparison.CompareColor;
            _colorComparison.OnCompared += _gameExodusDefiner.DefineExodus;
            _colorComparison.OnCompared += _similarityCounter.SetSimilarity;

        }


    }
}
