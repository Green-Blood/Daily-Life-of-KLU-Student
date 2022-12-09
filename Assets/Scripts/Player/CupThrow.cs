using Cysharp.Threading.Tasks;
using ExtentionMethods.Object_Pooler;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class CupThrow : IThrow
    {
        private readonly ObjectPooler _objectPooler;
        private readonly Tag _throwTag;
        private readonly PlayerSettings _playerSettings;
        private readonly IMovement _movement;
        private readonly Transform _characterTransform;

        public CupThrow(ObjectPooler objectPooler, Tag throwTag, IFacade characterFacade, PlayerSettings playerSettings,
            InputSystem inputSystem, IMovement movement)
        {
            _objectPooler = objectPooler;
            _throwTag = throwTag;
            _playerSettings = playerSettings;
            _movement = movement;
            _characterTransform = characterFacade.CharacterTransform;

            inputSystem.OnThrowInputAction.performed += OnThrow;
        }

        private async void OnThrow(InputAction.CallbackContext inputCallback) => await Throw();

        public async UniTask Throw()
        {
            var item = _objectPooler.SpawnFromPool(_throwTag, SetPositionOffset(), Quaternion.identity);
            var itemRigidBody = item.GetComponent<Rigidbody2D>();

            itemRigidBody.AddForce(_movement.Direction * _playerSettings.throwDistance, ForceMode2D.Impulse);

            // await UniTask.NextFrame();
        }

        private Vector3 SetPositionOffset() =>
            _characterTransform.position + _movement.Direction * _playerSettings.cupCreationOffset;
    }
}