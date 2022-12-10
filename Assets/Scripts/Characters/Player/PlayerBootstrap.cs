using Characters.Enemy;
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
        public CharacterHealth PlayerHealth => playerHealth;

        public void Construct(ObjectPooler objectPooler)
        {
            _inputSystem = new InputSystem(playerInput);
            playerHealth.Construct(playerSettings, playerDeath);
            _playerMovement = new PlayerMovement(playerFacade, playerSettings, _inputSystem);
            _playerThrow = new CupThrow(objectPooler, cupTag, playerFacade, playerSettings, _inputSystem,
                _playerMovement);
        }


        public void StartPlayer()
        {
            Observable.EveryFixedUpdate().Subscribe(l => { _playerMovement.Move(); });
        }
    }
}