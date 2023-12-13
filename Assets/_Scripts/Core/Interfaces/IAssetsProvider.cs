using UnityEngine;

namespace Root.Assets._Scripts.Core.Interfaces
{
    public interface IAssetsProvider
    {
        T Load<T>(string path) where T : Object;
    }
}