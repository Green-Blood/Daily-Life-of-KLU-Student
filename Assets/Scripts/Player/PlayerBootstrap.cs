using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerBootstrap : MonoBehaviour
    {
        [SerializeField] private PlayerFacade playerFacade;
        [SerializeField] private PlayerSettings playerSettings;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private ObjectPooler objectPooler;
        [SerializeField] private Tag cupTag;


        private PlayerMovement _playerMovement;
        private InputSystem _inputSystem;
        private CupThrow _playerThrow;

        public void Construct()
        {
            _inputSystem = new InputSystem(playerInput);
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