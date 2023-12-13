using System;

namespace Root.Assets._Scripts.Core.Interfaces
{
    public interface IUpdaterLoop
    {
        void AddListenerToUpdate(Action callBack);
        void AddListenerToFixedUpdate(Action callBack);
        void RemoveAllListenerToFixedUpdate();
        void RemoveAllListenerToUpdate();
    }
}
