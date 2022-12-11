using System;
using Characters.Interfaces;
using Characters.Player;
using UniRx;
using UnityEngine;
using UnityEngine.AI;

namespace Characters.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        private bool _canAttack = true;

        private NavMeshAgent _agent;
        private EnemySettings _enemySettings;
        private float _currentCooldown;

        public void Construct(EnemySettings enemySettings, NavMeshAgent enemyAgent)
        {
            _currentCooldown = enemySettings.attackCooldown;
            _agent = enemyAgent;
            _enemySettings = enemySettings;
        }

        private void Update()
        {
            if (!_agent.isActiveAndEnabled) return;
            // CheckAttack();

            // if (!IsInDistance()) return;
            // if (_canAttack) TryAttack();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.TryGetComponent(out PlayerBootstrap player))
            {
                player.PlayerHealth.TakeDamage(_enemySettings.attackDamage);
            }
        }

        private void CheckAttack()
        {
            if (_currentCooldown > 0) _currentCooldown -= Time.deltaTime;
            else _canAttack = true;
        }

        public void TryAttack()
        {
            Collider2D[] results = new Collider2D[2];
            Physics2D.OverlapCircleNonAlloc(_agent.destination - transform.position,
                _enemySettings.attackRadius, results, _enemySettings.pLayerMask);
            Debug.Log("Has Attacked ");
            _canAttack = false;
            _currentCooldown = _enemySettings.attackCooldown;

            if (results[0] == null) return;
            Debug.Log("Result is " + results[0]);
            if (results[0].TryGetComponent<IDamageable>(out var damageable))
                damageable.TakeDamage(_enemySettings.attackDamage);
            Debug.Log("Trying to take damage");
        }

        private bool IsInDistance() => _agent.remainingDistance <= _enemySettings.attackDistance;

        
    }
}