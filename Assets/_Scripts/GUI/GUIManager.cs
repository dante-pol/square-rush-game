using Root.Assets._Scripts.Core.Interfaces;
using Root.Assets._Scripts.Gameplay;
using Root.Assets._Scripts.GUI.Screens;
using UnityEngine;

namespace Root.Assets._Scripts.GUI
{
    public class GUIManager: MonoBehaviour
    {
        [SerializeField] private UIGameplayScreen _uiGameplayScreen;
        [SerializeField] private UIStartScreen _uiStartScreen;
        [SerializeField] private UIGameOverScreen _uiGameOverScreen;

        public void Init(IGameEventer game, GameProgress progress)
        {
            _uiGameplayScreen.Init(progress);
            _uiStartScreen.Init(this, game);
            _uiGameOverScreen.Init(progress, game);

            SetActiveAllScreens(false);

            SetActiveStartScreen(true);
        }

        public void SetActiveAllScreens(bool value)
        {
            _uiGameplayScreen.SetActive(value);
            _uiStartScreen.SetActive(value);
            _uiGameOverScreen.SetActive(value);
        }

        public void SetActiveStartScreen(bool value)
            => _uiStartScreen.SetActive(value);

        public void SetActiveGameplayScreen(bool value)
            => _uiGameplayScreen.SetActive(value);

        public void SetActiveGameOverScreen(bool value)
            => _uiGameOverScreen.SetActive(true);
    }
}
