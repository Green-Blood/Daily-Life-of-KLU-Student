using Characters.Interfaces;
using Characters.Player; 
using UnityEngine;

namespace Cups
{
    public class Cup : MonoBehaviour
    {
        [SerializeField] private PlayerSettings playerSettings;
        [SerializeField] private TriggerObserver triggerObserver;
        [SerializeField] private float rotateSpeed = 100;


        private void Awake() => triggerObserver.OnEnter += OnDamageableEnter;

        private void OnDamageableEnter(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(playerSettings.cupDamage);
            }

            gameObject.SetActive(false);
        }

        private void Update()
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }


        private void OnDestroy() => triggerObserver.OnEnter -= OnDamageableEnter;
    }
}