using System;
using UnityEngine;
using UnityEngine.AI;

namespace Characters.Enemy
{
    public class EnemyBootstrap : MonoBehaviour
    {
        [SerializeField] private EnemyHealth enemyHealth;
        [SerializeField] private EnemyDeath enemyDeath;
        [SerializeField] private EnemySettings enemySettings;
        [SerializeField] private NavMeshAgent agent;

        private Transform _playerTransform;

        public void Construct(Transform playerTransform)
        {
            enemyHealth.Construct(enemySettings, enemyDeath);
            _playerTransform = playerTransform;
        }

        private void Update()
        {
            agent.SetDestination(_playerTransform.position);
        }
    }
}