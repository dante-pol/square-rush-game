using Root.Assets._Scripts.Actors.Player;
using Root.Assets._Scripts.Core;
using Root.Assets._Scripts.Gameplay.InputSystems;
using Root.Assets._Scripts.Gameplay.Spawners;
using Root.Assets._Scripts.GUI;
using Root.Assets._Scripts.Tools;
using UnityEngine;

namespace Root.Assets._Scripts.Gameplay
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private PlayerModel _player;
        [SerializeField] private SpawnersManager _spawnersManager;
        [SerializeField] private GUIManager _guiManager;

        private GameBootstraper _bootstraper;

        private IGameEventer _gameEventer;
        private GameProgress _progress;
        private IInputSystem _inputSystem;

        private void Awake()
        {
            if (NeedGameBootstraping())
            {
                ScenesLoader.Load(IDScenes.INIT_SCENE);
                return;
            }

            InitComponentsSystem();
        }

        private void InitComponentsSystem()
        {
            _bootstraper = GameBootstraper.Instance;
            _gameEventer = new GameEventController(_bootstraper, _player, _spawnersManager, _guiManager);
            _inputSystem = new BaseInputSystem(_bootstraper, _gameEventer);
            _progress = new GameProgress(_gameEventer, _player);

            _player.Init(_bootstraper, _inputSystem, _gameEventer);
            _spawnersManager.Init(_bootstraper.MainFactory);
            _guiManager.Init(_gameEventer, _progress);
        }

        private bool NeedGameBootstraping()
            => GameBootstraper.Instance == null ? true : false;
    }
}
