using UnityEngine;

namespace Root.Assets._Scripts.Actors.Entityes
{
    public interface IEntity
    {
        void Dispose();
        void Push(Vector2 direction);
    }
}