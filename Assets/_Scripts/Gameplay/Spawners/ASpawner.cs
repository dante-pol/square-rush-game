using Root.Assets._Scripts.Actors.Entityes;
using Root.Assets._Scripts.Factoryes;
using System.Collections;
using UnityEngine;

namespace Root.Assets._Scripts.Gameplay.Spawners
{
    public abstract class ASpawner : ISpawner
    {
        protected readonly IMainFactory _factory;
        protected readonly SpawnersManager _spawnManager;

        protected readonly float _minIntervalToSpawn;
        protected readonly float _maxIntervalToSpawn;

        public ASpawner(IMainFactory factory, SpawnersManager spawnersManager)
        {
            _factory = factory;
            _spawnManager = spawnersManager;

            _minIntervalToSpawn = 1;
            _maxIntervalToSpawn = 3;
        }

        public void Run()
            => _spawnManager.StartCoroutine(Spawning());

        protected abstract IEnumerator Spawning();
        
        protected float GetIntervalToSpawn()
            => Random.Range(_minIntervalToSpawn, _maxIntervalToSpawn);

        protected abstract IEntity CreateObject(Transform parent, Vector2 position, Quaternion rotation);

    }
}
