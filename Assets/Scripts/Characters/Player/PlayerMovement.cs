using Characters.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Characters.Player
{
    public class PlayerMovement : IMovement
    {
        private readonly InputSystem _inputSystem;
        private readonly Rigidbody2D _rigidbody2D;
        private readonly float _playerSpeed;
        private Vector2 _moveInput;

        public Vector3 Direction { get; private set; }

        public PlayerMovement(IFacade playerFacade, PlayerSettings playerSettings, InputSystem inputSystem)
        {
            _inputSystem = inputSystem;
            _rigidbody2D = playerFacade.CharacterRigidBody;
            _playerSpeed = playerSettings.characterSpeed;

            SubscribeToEvents(inputSystem);
        }

        private void SubscribeToEvents(InputSystem inputSystem)
        {
            inputSystem.OnMoveInputAction.performed += OnMove;
            
        }

        private void OnMove(InputAction.CallbackContext inputValue)
        {
            SetInput(inputValue.action);
        }

        public void Move()
        {
            var normalizedInput = _moveInput.normalized;
            if (normalizedInput.sqrMagnitude > .1f) Direction = _moveInput.normalized;

            _rigidbody2D.MovePosition(_rigidbody2D.position + normalizedInput * _playerSpeed * Time.deltaTime);
        }

        private void SetInput(InputAction inputValue) => _moveInput = inputValue.ReadValue<Vector2>();
    }
}