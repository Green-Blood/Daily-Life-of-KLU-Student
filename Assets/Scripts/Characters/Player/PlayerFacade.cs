using Characters.Interfaces;
using UnityEngine;

namespace Characters.Player
{
    public class PlayerFacade : MonoBehaviour, IFacade
    {
        [SerializeField] private Rigidbody2D playerRigidBody;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Animator playerAnimator;


        public Transform CharacterTransform => transform;
        public Rigidbody2D CharacterRigidBody => playerRigidBody;
        public Animator CharacterAnimator => playerAnimator;

        public void FlipSprite(bool flip) => spriteRenderer.flipX = flip;
    }
}