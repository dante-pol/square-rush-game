using Root.Assets._Scripts.Actors.Player;
using Root.Assets._Scripts.Core;
using Root.Assets._Scripts.Gameplay.Spawners;
using Root.Assets._Scripts.GUI;
using Root.Assets._Scripts.Tools;
using System;

namespace Root.Assets._Scripts.Gameplay
{
    public class GameEventController : IGameEventer
    {
        private Action _onDisable;

        private readonly SpawnersManager _spawnersManager;
        private readonly GUIManager _guiManager;

        public GameEventController(
            GameBootstraper bootstraper,
            IPlayerEventer player, 
            SpawnersManager spawnersManager, 
            GUIManager guiManager)
        {
            player.AddHandlerOnDead(Quit);

            _spawnersManager = spawnersManager;
            _guiManager = guiManager;

            AddListenerToDisable(bootstraper.RemoveAllListenerToUpdate);
            AddListenerToDisable(bootstraper.RemoveAllListenerToFixedUpdate);
        }

        public void Run()
        {
            _spawnersManager.Run();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Quit()
        {
            _spawnersManager.IsSpawn = false;
            _guiManager.SetActiveGameOverScreen(true);
        }

        public void Restart()
        {
            _onDisable?.Invoke();
            
            RemoveAllListenerToDisable();

            ScenesLoader.Load(IDScenes.GAME_SCENE);
        }

        public void AddListenerToDisable(Action callBack)
            => _onDisable += callBack;

        public void RemoveAllListenerToDisable()
            => _onDisable = null;

    }
}
