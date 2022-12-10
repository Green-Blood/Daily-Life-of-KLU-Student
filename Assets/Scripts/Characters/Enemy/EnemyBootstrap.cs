using System;
using UnityEngine;
using UnityEngine.AI;

namespace Characters.Enemy
{
    public class EnemyBootstrap : MonoBehaviour
    {
        [SerializeField] private CharacterHealth characterHealth;
        [SerializeField] private EnemyDeath enemyDeath;
        [SerializeField] private EnemySettings enemySettings;
        [SerializeField] private NavMeshAgent agent;

        private Transform _playerTransform;

        public void Construct(Transform playerTransform)
        {
            characterHealth.Construct(enemySettings, enemyDeath);
            _playerTransform = playerTransform;
        }

        private void Update()
        {
            // agent.SetDestination(_playerTransform.position);
        }
    }
}