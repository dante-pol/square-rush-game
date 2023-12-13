using Root.Assets._Scripts.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace Root.Assets._Scripts.GUI.Screens
{
    public class UIGameplayScreen : MonoBehaviour
    {
        [SerializeField] private Text _txtScore;

        public void Init(GameProgress progress)
            => progress.AddListenerToOnIncreaseScore(UpdateUI);

        public void SetActive(bool value)
            => gameObject.SetActive(value);

        public void UpdateUI(int value)
            => _txtScore.text = value.ToString();
    }
}
