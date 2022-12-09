using System;
using Player;
using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        private StateMachine _stateMachine;
        [SerializeField] private PlayerBootstrap playerBootstrap;

        private void Awake()
        {
            _stateMachine = new StateMachine();
        }

        private void Start()
        {
            _stateMachine.OnStateChange += OnStateChange;
            _stateMachine.Enter(State.GameStart);

            playerBootstrap.Construct();

            // TODO Change it with the game state 
            playerBootstrap.StartPlayer();
        }

        private void OnStateChange(State state)
        {
            switch (state)
            {
                case State.GameStart:
                    break;
                case State.GameEnd:
                    break;
                case State.GameFinish:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }
}