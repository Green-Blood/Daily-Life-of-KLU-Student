using Player;
using UnityEngine;

namespace Characters.Enemy
{
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        private int _currentHealth;
        private int _maxHealth;
        private IDie _enemyDeath;

        public void Construct(EnemySettings enemySettings, IDie enemyDeath)
        {
            _maxHealth = enemySettings.health;
            _enemyDeath = enemyDeath;
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(int amount)
        {
            _currentHealth -= amount;
            Debug.Log("Enemy health is" + _currentHealth);
            if (_currentHealth <= 0)
            {
                _enemyDeath.Die();
            }
        }
    }
}