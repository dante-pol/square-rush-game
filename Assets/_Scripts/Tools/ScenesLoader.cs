using UnityEngine.SceneManagement;

namespace Root.Assets._Scripts.Tools
{
    public enum IDScenes { INIT_SCENE = 0, GAME_SCENE = 1 }
    public static class ScenesLoader
    {
        public static void Load(IDScenes idScene) 
            => SceneManager.LoadScene((int) idScene);
    }
}
