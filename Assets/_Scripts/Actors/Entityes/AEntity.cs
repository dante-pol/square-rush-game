using UnityEngine;

namespace Root.Assets._Scripts.Actors.Entityes
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
    public abstract class AEntity : MonoBehaviour, IEntity
    {
        [SerializeField][Range(0, 3)] protected float _speedMove;

        protected Rigidbody2D _rigidbody2D;
        protected Animator _animator;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("wall"))
                CollisionWall();
        }

        public void Push(Vector2 direction)
        {
            if (_rigidbody2D == null) { _rigidbody2D = GetComponent<Rigidbody2D>(); }
            Move(direction);
            Rotate();
        }

        protected void Move(Vector2 direction)
            => _rigidbody2D.velocity = direction * _speedMove;

        protected void Rotate()
            => _rigidbody2D.AddTorque(_speedMove, ForceMode2D.Impulse);

        public abstract void Dispose();

        public abstract void CollisionWall();
    }
}
