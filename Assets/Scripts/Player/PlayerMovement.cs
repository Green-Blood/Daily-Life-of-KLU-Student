using UnityEngine;

namespace Player
{
    public class PlayerMovement
    {
        private readonly Rigidbody2D _rigidbody2D;
        private readonly float _playerSpeed;

        public PlayerMovement(IFacade playerFacade, PlayerSettings playerSettings)
        {
            _rigidbody2D = playerFacade.CharacterRigidBody;
            _playerSpeed = playerSettings.playerSpeed;
        }

        public void Move()
        {
            var playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            var normalizedInput = playerInput.normalized;
            _rigidbody2D.velocity = playerInput.normalized * _playerSpeed;
        }
    }
}