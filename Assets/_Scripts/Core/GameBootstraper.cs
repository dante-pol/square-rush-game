using Root.Assets._Scripts.Core.Interfaces;
using Root.Assets._Scripts.Factoryes;
using Root.Assets._Scripts.Tools;
using UnityEngine;

namespace Root.Assets._Scripts.Core
{
    
    public class GameBootstraper : GlobalTool
    {
        public static GameBootstraper Instance { get; private set;}

        public IAssetsProvider AssetsProvider { get; private set; }
        public IMainFactory MainFactory  { get; private set; }

        private void Start()
        {
            if (NeedBootstraping()) return;

            DontDestroyOnLoad(gameObject);
            
            LoadConfig();

            LoadGame();
        }

        private void LoadConfig() 
        {
            AssetsProvider = new AssetsProvider();
            MainFactory = new MainFactory(AssetsProvider);
        }

        private void LoadGame()
            => ScenesLoader.Load(IDScenes.GAME_SCENE);

        private bool NeedBootstraping()
            => Instance == null ? !(Instance = this) : true;
    }
}
