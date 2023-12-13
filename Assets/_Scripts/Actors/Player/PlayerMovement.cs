using UnityEngine;

namespace Root.Assets._Scripts.Actors.Player
{
    public class PlayerMovement
    {
        public readonly PlayerModel Player;
        public readonly Rigidbody2D Rigidbody;

        private float _directionX;

        public PlayerMovement(PlayerModel player, Rigidbody2D rigidbody)
        {
            Player = player;
            Rigidbody = rigidbody;

            _directionX = 1;
        }

        public void CheckBorder()
        {
            var position = Player.transform.position;

            if (position.x >= Player.RightBorder)
            {
                Player.transform.position = new Vector2(Player.RightBorder, Player.transform.position.y);
                ChangeDirectionMove();
            }
            if (position.x < Player.LeftBorder)
            {
                Player.transform.position = new Vector2(Player.LeftBorder, Player.transform.position.y);
                ChangeDirectionMove();
            }
        }

        public void Move()
        {
            Vector2 velocity = _directionX * Vector2.right * Player.SpeedMove;
            Rigidbody.velocity = velocity;
        }

        public void ChangeDirectionMove()
        {
            _directionX *= -1; 
        }
    }
}
