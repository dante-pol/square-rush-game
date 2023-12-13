using Root.Assets._Scripts.Core.Interfaces;
using UnityEngine;

namespace Root.Assets._Scripts.Core
{
    public class AssetsProvider : IAssetsProvider
    {
        public static string PATH_TO_ENEMY = "Actors/Enemy";
        public static string PATH_TO_CURRENCY = "Actors/Currency"; 

        public T Load<T>(string path) where T : Object
        {
            T resource = Resources.Load<T>(path);

            return resource;
        }
    }
}
