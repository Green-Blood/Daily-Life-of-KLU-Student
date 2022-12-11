using System;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.AI;

namespace Characters.Enemy
{
    public class EnemyBootstrap : MonoBehaviour
    {
        [SerializeField] private CharacterHealth enemyHealth;
        [SerializeField] private EnemyDeath enemyDeath;
        [SerializeField] private EnemySettings enemySettings;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private EnemyAttack enemyAttack;
        [SerializeField] private SpriteRenderer playerSprite;
        [SerializeField] private MMF_Player followFeedback;
        


        private Transform _playerTransform;

        public void Construct(Transform playerTransform)
        {
            enemyHealth.Construct(enemySettings, enemyDeath);

            _playerTransform = playerTransform;

            agent.speed = enemySettings.characterSpeed;
            agent.updateRotation = false;
            agent.updateUpAxis = false;
            enemyAttack.Construct(enemySettings, agent);
        }

        private void Update()
        {
            agent.SetDestination(_playerTransform.position);
            if (agent.destination.x < transform.position.x)
            {
                playerSprite.flipX = true;
            }
            else
            {
                playerSprite.flipX = false;
            }

            if (!followFeedback.IsPlaying)
            {
                followFeedback.PlayFeedbacks();
            }
        }
    }
}