using System;
// using Characters.Interfaces;
// using Characters.Player;
using Player;
using UnityEngine;

namespace Cups
{
    public class Cup : MonoBehaviour
    {
        [SerializeField] private PlayerSettings playerSettings;
        [SerializeField] private TriggerObserver triggerObserver;

        private void Awake() => triggerObserver.OnEnter += OnDamageableEnter;

        private void OnDamageableEnter(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(playerSettings.cupDamage);
            }
        }

        private void OnDestroy() => triggerObserver.OnEnter -= OnDamageableEnter;
    }
}