using Characters.Enemy;
using Core;
using ExtentionMethods.Object_Pooler;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Characters.Player
{
    public class PlayerBootstrap : MonoBehaviour
    {
        [SerializeField] private PlayerFacade playerFacade;
        [SerializeField] private PlayerSettings playerSettings;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private CharacterHealth playerHealth;
        [SerializeField] private PlayerDeath playerDeath;
        [SerializeField] private Tag cupTag;

        private PlayerMovement _playerMovement;
        private InputSystem _inputSystem;
        private CupThrow _playerThrow;
        private StateMachine _stateMachine;
        public CharacterHealth PlayerHealth => playerHealth;

        public void Construct(ObjectPooler objectPooler, StateMachine stateMachine)
        {
            _inputSystem = new InputSystem(playerInput);
            playerHealth.Construct(playerSettings, playerDeath);
            _playerMovement = new PlayerMovement(playerFacade, playerSettings, _inputSystem);
            _playerThrow = new CupThrow(objectPooler, cupTag, playerFacade, playerSettings, _inputSystem,
                _playerMovement);
            playerHealth.OnHealthChanged += OnHealthChanged;
            _stateMachine = stateMachine;
        }

        private void OnHealthChanged(int currentHealth, int maxHealth)
        {
            if (_stateMachine.CurrentState == State.MathiasCanStart || _stateMachine.CurrentState == State.TomCanStart)
            {
                
            }
            if (currentHealth == maxHealth / 2)
            {
                AudioSystem.Instance.StartExplore50();
            }
        }

        public void ToggleMovement(bool value)
        {
            _playerMovement.ToggleMovement(value);
        }

        public void StartPlayer()
        {
            Observable.EveryFixedUpdate().Subscribe(l => { _playerMovement.Move(); });
        }
    }
}