using UnityEngine;

namespace Characters.Interfaces
{
    public interface IFacade
    {
        public Transform CharacterTransform { get; }
        public Rigidbody2D CharacterRigidBody { get; }
    }
}