using System;

namespace Root.Assets._Scripts.Gameplay.InputSystems
{
    public interface IInputSystem
    {
        void AddListenerToOnTap(Action callBack);
        void CheckTap();
    }
}