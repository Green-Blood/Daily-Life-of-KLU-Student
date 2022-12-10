using Characters.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Characters.Player
{
    public class PlayerMovement : IMovement
    {
        private readonly IFacade _playerFacade;
        private readonly InputSystem _inputSystem;
        private readonly Rigidbody2D _rigidbody2D;
        private readonly float _playerSpeed;
        private Vector2 _moveInput;
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private bool _canMove = true;

        public Vector3 Direction { get; private set; }

        public PlayerMovement(IFacade playerFacade, PlayerSettings playerSettings, InputSystem inputSystem)
        {
            _playerFacade = playerFacade;
            _inputSystem = inputSystem;
            _rigidbody2D = playerFacade.CharacterRigidBody;
            _playerSpeed = playerSettings.characterSpeed;

            SubscribeToEvents(inputSystem);
        }

        private void SubscribeToEvents(InputSystem inputSystem)
        {
            inputSystem.OnMoveInputAction.performed += OnMove;
            inputSystem.OnMoveInputAction.canceled += StopMoving;
            
        }

        private void OnMove(InputAction.CallbackContext inputValue)
        {
            if(!_canMove) return;
            SetInput(inputValue.action);
            _playerFacade.CharacterAnimator.SetBool(IsMoving, true);
        }

        public void Move()
        {
           
            var normalizedInput = _moveInput.normalized;

            if (normalizedInput.sqrMagnitude > .1f)
            {
                Direction = _moveInput.normalized;
            }

            _playerFacade.FlipSprite(Direction.x < 0);

            _rigidbody2D.MovePosition(_rigidbody2D.position + normalizedInput * _playerSpeed * Time.deltaTime);
        }

        private void SetInput(InputAction inputValue)
        {
            _moveInput = inputValue.ReadValue<Vector2>();
        }

        private void StopMoving(InputAction.CallbackContext obj)
        {
            _moveInput = Vector2.zero;
            _playerFacade.CharacterAnimator.SetBool(IsMoving, false);
        }

        public void ToggleMovement(bool value) => _canMove = value;
    }
}