using UnityEngine;

namespace Player
{
    public class PlayerFacade : MonoBehaviour, IFacade
    {
        [SerializeField] private Rigidbody2D playerRigidBody;
        
        public Transform CharacterTransform => transform;
        public Rigidbody2D CharacterRigidBody => playerRigidBody;
    }
}