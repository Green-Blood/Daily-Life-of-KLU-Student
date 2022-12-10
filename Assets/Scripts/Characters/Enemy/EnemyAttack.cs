using System;
using UniRx;

namespace Characters.Enemy
{
    public class EnemyAttack
    {
        private float _attackCooldown;
        private bool _canAttack;

        public EnemyAttack(EnemySettings enemySettings)
        {
            _attackCooldown = enemySettings.attackCooldown;
        }

        public void TryAttack()
        {
            if (_canAttack)
            {
                Observable.Timer(TimeSpan.FromSeconds(_attackCooldown)).Subscribe(l =>
                {
                    
                });
            }
        }
    }
}