using System;

namespace Core
{
    public class StateMachine
    {
        private State _currentState;
        public Action<State> OnStateChange;

        public void Enter(State state)
        {
            _currentState = state;
            OnStateChange?.Invoke(_currentState);
        }
    }
}