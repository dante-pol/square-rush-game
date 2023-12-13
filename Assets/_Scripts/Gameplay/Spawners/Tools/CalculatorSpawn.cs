using UnityEngine;

namespace Root.Assets._Scripts.Gameplay.Spawners.Tools
{
    public class CalculatorSpawn : ICalculatorSpawn
    {
        private readonly SpawnersManager _spawnersManager;

        private PointSpawn _currentPointSpawn;

        public CalculatorSpawn(SpawnersManager spawnersManager)
            => _spawnersManager = spawnersManager;

        public void ChangePointSpawn()
            => _currentPointSpawn = _spawnersManager.GetRandomPointSpawn();

        public Vector2 GetPosition()
            => _currentPointSpawn.Position;

        public Vector2 GetDirectionMove()
        {
            float angle = Random.Range(_currentPointSpawn.MinAngle, _currentPointSpawn.MaxAngle);

            float x = Mathf.Sin(angle * Mathf.Deg2Rad);
            float y = Mathf.Cos(angle * Mathf.Deg2Rad);

            return new Vector2(x, y);
        }
    }
}
