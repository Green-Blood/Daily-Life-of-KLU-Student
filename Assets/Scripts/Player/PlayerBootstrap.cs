using UniRx;
using UnityEngine;

namespace Player
{
    public class PlayerBootstrap : MonoBehaviour
    {
        [SerializeField] private PlayerFacade playerFacade;
        [SerializeField] private PlayerSettings playerSettings;
        private PlayerMovement _playerMovement;

        public void Construct()
        {
            _playerMovement = new PlayerMovement(playerFacade, playerSettings);
        }

        public void StartPlayer()
        {
            Observable.EveryFixedUpdate().Subscribe(l => { _playerMovement.Move(); });
        }
    }
}