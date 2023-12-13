using Root.Assets._Scripts.Core.Interfaces;
using System;
using UnityEngine;

namespace Root.Assets._Scripts.Gameplay.InputSystems
{
    public class BaseInputSystem : IInputSystem
    {
        protected Action _onTap;

        public BaseInputSystem(IUpdaterLoop updaterLoop, IGameEventer gameEventer)
        {
            updaterLoop.AddListenerToUpdate(CheckTap);
            gameEventer.AddListenerToDisable(RemoveAllListeners);
        }

        public void AddListenerToOnTap(Action callBack)
            => _onTap += callBack;

        public void RemoveAllListeners()
            => _onTap = null;

        public virtual void CheckTap()
        {
            if (Input.GetKeyDown(KeyCode.Space)) _onTap?.Invoke();
        }
    }
}
