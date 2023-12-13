using UnityEngine;

namespace Root.Assets._Scripts.Gameplay.Spawners.Tools
{
    public interface ICalculatorSpawn
    {
        void ChangePointSpawn();
        Vector2 GetDirectionMove();
        Vector2 GetPosition();
    }
}