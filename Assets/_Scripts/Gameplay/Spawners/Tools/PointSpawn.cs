using Unity.VisualScripting;
using UnityEngine;

namespace Root.Assets._Scripts.Gameplay.Spawners.Tools
{
    public class PointSpawn : MonoBehaviour
    {
        public float MinAngle => _minAngle;
        public float MaxAngle => _maxAngle;

        public Vector2 Position => transform.position;

        [SerializeField] [Range(-180, 180)] private float _minAngle;
        [SerializeField] [Range(-180, 180)] private float _maxAngle;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            Gizmos.DrawRay(Position, GetDirectionMove(_maxAngle) * 2);
            Gizmos.DrawRay(Position, GetDirectionMove(_minAngle) * 2);
        }

        public Vector2 GetDirectionMove(float angle)
        {
            float x = Mathf.Sin(angle * Mathf.Deg2Rad);
            float y = Mathf.Cos(angle * Mathf.Deg2Rad);

            return new Vector2(x, y);
        }
    }
}
