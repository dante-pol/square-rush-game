using DG.Tweening;
using Root.Assets._Scripts.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace Root.Assets._Scripts.GUI.Screens
{
    public class UIStartScreen : MonoBehaviour
    {
        [SerializeField] private Button _btnPlay;
        [SerializeField] private GameObject _text;

        public void Init(GUIManager manager, IGameEventer game)
        {
            _btnPlay.onClick.AddListener(() =>
            {
                game.Run();
                manager.SetActiveGameplayScreen(true);
                SetActive(false);
            });

            game.AddListenerToDisable(() => { _btnPlay.onClick.RemoveAllListeners(); });
            
            //TODO: Add animation for button's text
            _text.transform.DOScale(.7f, 1).SetEase(Ease.InOutCirc).SetLoops(-1, LoopType.Yoyo);
        }

        public void SetActive(bool value)
            => gameObject.SetActive(value);
    }
}
