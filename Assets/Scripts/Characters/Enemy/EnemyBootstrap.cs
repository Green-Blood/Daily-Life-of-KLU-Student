using UnityEngine;

namespace Characters.Enemy
{
    public class EnemyBootstrap : MonoBehaviour
    {
        [SerializeField] private EnemyHealth enemyHealth;
        [SerializeField] private EnemyDeath enemyDeath;
        [SerializeField] private EnemySettings enemySettings;

        public void Construct()
        {
            enemyHealth.Construct(enemySettings, enemyDeath);
        }
    }
}