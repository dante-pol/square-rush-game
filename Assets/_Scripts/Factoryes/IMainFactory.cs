using Root.Assets._Scripts.Actors.Entityes;
using UnityEngine;

namespace Root.Assets._Scripts.Factoryes
{
    public interface IMainFactory
    {
        IEntity CreateCurrency(Transform parent, Vector2 position, Quaternion rotation);
        IEntity CreateEnemy(Transform parent, Vector2 position, Quaternion rotation);
        GameObject CreatePlayer(Transform parent, Vector2 position, Quaternion rotation);
    }
}