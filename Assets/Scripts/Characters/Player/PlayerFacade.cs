using Characters.Interfaces;
using UnityEngine;

namespace Characters.Player
{
    public class PlayerFacade : MonoBehaviour, IFacade
    {
        [SerializeField] private Rigidbody2D playerRigidBody;
        
        public Transform CharacterTransform => transform;
        public Rigidbody2D CharacterRigidBody => playerRigidBody;
    }
}