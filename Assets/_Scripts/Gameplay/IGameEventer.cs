using System;
using Unity.VisualScripting;

namespace Root.Assets._Scripts.Gameplay
{
    public interface IGameEventer
    {
        void Quit();
        void Run();
        void Save();
        void Restart();

        void AddListenerToDisable(Action callBack);
        void RemoveAllListenerToDisable();
    }
}