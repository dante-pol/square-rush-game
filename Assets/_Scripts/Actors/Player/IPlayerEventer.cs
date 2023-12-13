using System;

namespace Root.Assets._Scripts.Actors.Player
{
    public interface IPlayerEventer
    {
        void AddHandlerOnDead(Action callBack);
        void AddHandlerToOnTakeCurrency(Action<int> callBack);
        void RemoveAllHandlersToOnDead();
        void RemoveAllHandlersToOnTakeCurrency();
    }
}