using Root.Assets._Scripts.Actors.Player;
using System;

namespace Root.Assets._Scripts.Gameplay
{
    public class GameProgress
    {
        public int Score => _score;
        private int _score;
        
        private Action<int> OnIncreaseScore;

        public GameProgress(IGameEventer gameEventer, IPlayerEventer playerEventer)
        {
            playerEventer.AddHandlerToOnTakeCurrency(IncreaseScore);
            gameEventer.AddListenerToDisable(RemoveAllListenersToOnIncreaseScore);
        }

        public void IncreaseScore(int value)
        {
            _score += value;

            OnIncreaseScore?.Invoke(_score);
        }

        public void AddListenerToOnIncreaseScore(Action<int> callBack)
            => OnIncreaseScore += callBack;

        public void RemoveAllListenersToOnIncreaseScore()
            => OnIncreaseScore = null;

    }
}
