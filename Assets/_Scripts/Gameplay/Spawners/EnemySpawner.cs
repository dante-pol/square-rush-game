using Root.Assets._Scripts.Actors.Entityes;
using Root.Assets._Scripts.Factoryes;
using Root.Assets._Scripts.Gameplay.Spawners.Tools;
using System.Collections;
using UnityEngine;

namespace Root.Assets._Scripts.Gameplay.Spawners
{
    public class EnemySpawner : ASpawner
    {
        public EnemySpawner(IMainFactory factory, SpawnersManager spawnersManager) : base(factory, spawnersManager)
        {
        }

        protected override IEntity CreateObject(Transform parent, Vector2 position, Quaternion rotation)
        {
            return _factory.CreateEnemy(parent, position, rotation);
        }

        protected override IEnumerator Spawning()
        {
            ICalculatorSpawn calculatorSpawn = _spawnManager.CalculatorSpawn;

            while (_spawnManager.IsSpawn)
            {
                calculatorSpawn.ChangePointSpawn();

                IEntity entity = CreateObject(_spawnManager.ContainerCurrency, calculatorSpawn.GetPosition(), Quaternion.identity);
                entity.Push(calculatorSpawn.GetDirectionMove());

                yield return new WaitForSeconds(GetIntervalToSpawn());
            }
        }
    }
}
