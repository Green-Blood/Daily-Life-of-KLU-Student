using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class InputSystem
    {
        public InputAction OnThrowInputAction { get; }
        public InputAction OnMoveInputAction { get; }

        public InputSystem(PlayerInput playerInput)
        {
            OnThrowInputAction = playerInput.actions["Throw"];
            OnMoveInputAction = playerInput.actions["Move"];
        }
       
 
    }
}