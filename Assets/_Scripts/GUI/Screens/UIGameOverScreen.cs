using Root.Assets._Scripts.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace Root.Assets._Scripts.GUI.Screens
{
    public class UIGameOverScreen : MonoBehaviour
    {
        [SerializeField] private Text _txtScore;
        [SerializeField] private Button _btnPlay;

        private GameProgress _progress;

        public void Init(GameProgress progress, IGameEventer gameEventer)
        {
            _progress = progress;
            _btnPlay.onClick.AddListener(() =>
            {
                gameEventer.Restart();
            });

            gameEventer.AddListenerToDisable(() => { _btnPlay.onClick.RemoveAllListeners(); });
        }

        public void UpdateUI()
            => _txtScore.text = _progress.Score.ToString();

        public void SetActive(bool v)
        {
            gameObject.SetActive(v);
            UpdateUI();
        }
    }
}
