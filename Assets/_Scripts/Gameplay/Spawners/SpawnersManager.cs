using Root.Assets._Scripts.Factoryes;
using Root.Assets._Scripts.Gameplay.Spawners.Tools;
using UnityEngine;

namespace Root.Assets._Scripts.Gameplay.Spawners
{
    public class SpawnersManager : MonoBehaviour
    {
        #region Containers
        [SerializeField] private PointSpawn[] _pointSpawn;
        public Transform ContainerMain => _containerMain.transform;
        public Transform ContainerEnemy => _containerEnemy.transform;
        public Transform ContainerCurrency => _containerCurrency.transform;


        private GameObject _containerMain;
        private GameObject _containerEnemy;
        private GameObject _containerCurrency;
        #endregion

        #region Spawners
        public bool IsSpawn { get; set; }
        public ICalculatorSpawn CalculatorSpawn => _calculatorSpawn;
        private ICalculatorSpawn _calculatorSpawn;

        private ISpawner _spawnerEnemy;
        private ISpawner _spawnerCurrency;
        #endregion

        public void Init(IMainFactory factory)
        {
            _containerMain = new GameObject("MainContainer");
            _containerEnemy = new GameObject("EnemyContainer");
            _containerCurrency = new GameObject("CurrencyContainer");

            IsSpawn = true;
            
            _calculatorSpawn = new CalculatorSpawn(this);
            _spawnerCurrency = new CurrencySpawner(factory, this);
            _spawnerEnemy = new EnemySpawner(factory, this);

            ConfigurateContainers();
        }

        public void Run()
        {
            _spawnerEnemy.Run();
            _spawnerCurrency.Run();
        }

        public PointSpawn GetRandomPointSpawn()
            => _pointSpawn[Random.Range(0, _pointSpawn.Length)];

        private void ConfigurateContainers()
        {
            _containerEnemy.transform.parent = _containerMain.transform;
            _containerCurrency.transform.parent = _containerMain.transform;
        }
    }
}
