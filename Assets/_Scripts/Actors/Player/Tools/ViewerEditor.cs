using UnityEditor;
using UnityEngine;

namespace Root.Assets._Scripts.Actors.Player.Tools
{
    [CustomEditor(typeof(PlayerModel))]
    public class ViewerEditor : Editor
    {
        private PlayerModel _model;

        private void OnSceneGUI()
        {
            _model = target as PlayerModel;

            Vector2 start = new Vector2(_model.LeftBorder, 0);
            Vector2 end = new Vector2(_model.RightBorder, 0);

            Handles.DrawLine(start, end);
        }
    }
}
