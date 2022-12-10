using System;

namespace Core
{
    public class StateMachine
    {
        public State CurrentState { get; private set; }
        public Action<State> OnStateChange;

        public void Enter(State state)
        {
            CurrentState = state;
            OnStateChange?.Invoke(CurrentState);
        }
    }
}