using Root.Assets._Scripts.Actors.Entityes;
using Root.Assets._Scripts.Actors.Player;
using Root.Assets._Scripts.Core;
using Root.Assets._Scripts.Core.Interfaces;
using UnityEngine;

namespace Root.Assets._Scripts.Factoryes
{
    public class MainFactory : IMainFactory
    {
        private PlayerModel _prefabPlayer;
        private EnemyEntity _prefabEnemy;
        private CurrencyEntity _prefabCurrency;

        public MainFactory(IAssetsProvider assetsProvider)
        {
            _prefabEnemy = assetsProvider.Load<EnemyEntity>(AssetsProvider.PATH_TO_ENEMY);
            _prefabCurrency = assetsProvider.Load<CurrencyEntity>(AssetsProvider.PATH_TO_CURRENCY);

            //_prefabPlayer = assetsProvider.Load<PlayerModel>();
            
        }

        public IEntity CreateCurrency(Transform parent, Vector2 position, Quaternion rotation)
        {
            CurrencyEntity currency = Instantiate(_prefabCurrency, parent, position, rotation);
            return currency;
        }

        public IEntity CreateEnemy(Transform parent, Vector2 position, Quaternion rotation)
        {
            EnemyEntity enemy = Instantiate(_prefabEnemy, parent, position, rotation);
            return enemy;
        }

        public GameObject CreatePlayer(Transform parent, Vector2 position, Quaternion rotation)
        {
            throw new System.NotImplementedException();
        }

        private T Instantiate<T>(T prefab, Transform parent, Vector2 position, Quaternion rotation) where T : Object
            => Object.Instantiate(prefab, position, rotation, parent);
    }
}
