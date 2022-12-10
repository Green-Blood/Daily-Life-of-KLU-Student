using UnityEngine;

namespace Player
{
    public interface IFacade
    {
        public Transform CharacterTransform { get; }
        public Rigidbody2D CharacterRigidBody { get; }
    }
}