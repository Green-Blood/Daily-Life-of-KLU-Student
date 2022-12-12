using System;
using Characters.Interfaces;
using Characters.Player;
using UnityEngine;

namespace Characters.Enemy
{
    public class CharacterHealth : MonoBehaviour, IDamageable
    {
        private int _currentHealth;
        private int _maxHealth;
        private IDie _characterDeath;
        public Action<int, int> OnHealthChanged;
        public int CurrentHealth => _currentHealth;
        public int MaxHealth => _maxHealth;
        private bool isDead;

        public void Construct(CharacterSettings enemySettings, IDie enemyDeath)
        {
            _maxHealth = enemySettings.characterHealth;
            _characterDeath = enemyDeath;
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(int amount)
        {
            if(isDead) return;
            _currentHealth -= amount;
            Validate();

            OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
            Debug.Log("Current health of " + gameObject.name + " is "  + _currentHealth  ) ;
            if (_currentHealth <= 0)
            {
                isDead = true;
                _characterDeath.Die();
            }
        }

        private void Validate()
        {
            if (_currentHealth < 0)
            {
                _currentHealth = 0;
            }

            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
        }
    }
}