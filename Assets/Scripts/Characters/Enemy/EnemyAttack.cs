using System;
using Characters.Interfaces;
using UniRx;
using UnityEngine;
using UnityEngine.AI;

namespace Characters.Enemy
{
    public class EnemyAttack
    {
        private float _attackCooldown;
        private bool _canAttack;

        private NavMeshAgent _agent;
        private EnemySettings _enemySettings;

        public EnemyAttack(EnemySettings enemySettings, NavMeshAgent enemyAgent)
        {
            _attackCooldown = enemySettings.attackCooldown;
            _agent = enemyAgent;
            Observable.EveryUpdate().Subscribe((l =>
            {
                if(!enemyAgent.isActiveAndEnabled) return;
                if (enemyAgent.remainingDistance <= enemySettings.attackDistance)
                {
                    TryAttack();
                }
            }));
        }

        public void TryAttack()
        {
            Observable.Timer(TimeSpan.FromSeconds(_attackCooldown)).Subscribe(l =>
            {
                // var player = Physics2D.OverlapCircle( _agent.destination - _agent.transform.position, _enemySettings.attackRadius,
                //     _enemySettings.pLayerMask);
                // if (player == null) return;
                // if (player.TryGetComponent<IDamageable>(out var damageable))
                //     damageable.TakeDamage(_enemySettings.attackDamage);
            });
        }
    }
}