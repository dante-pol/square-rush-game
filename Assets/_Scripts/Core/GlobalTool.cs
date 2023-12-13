using Root.Assets._Scripts.Core.Interfaces;
using System;
using UnityEngine;

namespace Root.Assets._Scripts.Core
{
    public class GlobalTool : MonoBehaviour, IUpdaterLoop
    {
        private Action _update;
        private Action _fixedUpdate;

        private void Update()
            => _update?.Invoke();

        private void FixedUpdate()
            => _fixedUpdate?.Invoke();

        public void AddListenerToFixedUpdate(Action callBack)
            => _fixedUpdate += callBack;

        public void AddListenerToUpdate(Action callBack)
            => _update += callBack;

        public void RemoveAllListenerToUpdate()
            => _update = null;

        public void RemoveAllListenerToFixedUpdate()
            => _fixedUpdate = null;
    }
}
