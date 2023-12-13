using Root.Assets._Scripts.Actors.Entityes;
using Root.Assets._Scripts.Core.Interfaces;
using Root.Assets._Scripts.Gameplay;
using Root.Assets._Scripts.Gameplay.InputSystems;
using System;
using UnityEngine;

namespace Root.Assets._Scripts.Actors.Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
    public class PlayerModel : MonoBehaviour, IPlayerEventer
    {
        #region Configuration
        public float SpeedMove => _speedMove;
        public float LeftBorder => _leftBorder;
        public float RightBorder => _rightBorder;

        [Header("Movement config")]
        [SerializeField][Range(0, 3)] private float _speedMove;
        [SerializeField][Range(-5, 0)] private float _leftBorder;
        [SerializeField][Range(0, 5)] private float _rightBorder;
        #endregion

        #region PlayerDependency
        private Rigidbody2D _rigidbody2D;
        private PlayerMovement _playerMovement;
        #endregion

        #region Actions
        private Action<int> OnTakeCurrency;
        private Action OnDead;
        #endregion

        public void Init(IUpdaterLoop updaterLoop, IInputSystem inputSystem, IGameEventer gameEventer)
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();

            _playerMovement = new PlayerMovement(this, _rigidbody2D);

            updaterLoop.AddListenerToUpdate(_playerMovement.CheckBorder);
            updaterLoop.AddListenerToFixedUpdate(_playerMovement.Move);

            gameEventer.AddListenerToDisable(RemoveAllHandlersToOnDead);
            gameEventer.AddListenerToDisable(RemoveAllHandlersToOnTakeCurrency);

            inputSystem.AddListenerToOnTap(_playerMovement.ChangeDirectionMove);
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            IEntity entity = other.GetComponent<AEntity>();

            if (other.CompareTag("enemy"))
            {
                OnDead?.Invoke();
            }
            else if (other.CompareTag("currency"))
            {
                OnTakeCurrency?.Invoke(1);
            }

            entity.Dispose();
        }

        public void AddHandlerToOnTakeCurrency(Action<int> callBack)
            => OnTakeCurrency += callBack;

        public void AddHandlerOnDead(Action callBack)
            => OnDead += callBack;

        public void RemoveAllHandlersToOnTakeCurrency()
            => OnTakeCurrency = null;

        public void RemoveAllHandlersToOnDead()
            => OnDead = null;
    }
}
