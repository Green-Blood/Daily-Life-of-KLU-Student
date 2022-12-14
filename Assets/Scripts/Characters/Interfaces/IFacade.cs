using MoreMountains.Feedbacks;
using UnityEngine;

namespace Characters.Interfaces
{
    public interface IFacade
    {
        public Transform CharacterTransform { get; }
        public Rigidbody2D CharacterRigidBody { get; }
        public Animator CharacterAnimator { get; }
        void FlipSprite(bool flip);
        MMF_Player RunFeedback { get; }
    }
}