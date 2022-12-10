using System.Collections;
using Characters.Enemy;
using UnityEngine;
using UnityEngine.UI;

namespace Characters
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image healthBarImage;
        [SerializeField] private float healthBarUpdateTime;

        public void Construct(CharacterHealth characterHealth)
        {
            characterHealth.OnHealthChanged += OnHealthChangedAction;
        }

        private void OnHealthChangedAction(int currentHealth, int maxHealth)
        {
            var amount = currentHealth / (float)maxHealth;
            StartCoroutine(OnHealthChangedCoroutine(amount));
        }

        private IEnumerator OnHealthChangedCoroutine(float amount)
        {
            float imageFillPercent = healthBarImage.fillAmount;
            float elapsed = 0f;

            while (elapsed < healthBarUpdateTime)
            {
                elapsed += Time.deltaTime;
                healthBarImage.fillAmount = Mathf.Lerp(imageFillPercent, amount, elapsed / healthBarUpdateTime);
                yield return null;
            }

            healthBarImage.fillAmount = amount;
        }
    }
}