using UnityEngine;

namespace Characters.Enemy
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        [SerializeField] private Tag enemyTag;
        private ObjectPooler _objectPooler;

        public void Construct(ObjectPooler objectPooler)
        {
            _objectPooler = objectPooler;
        }

        public void SpawnEnemy()
        {
            // var enemy = _objectPooler.SpawnFromPool(enemyTag, transform.position, Quaternion.identity);
            // enemy.GetComponent<EnemyBootstrapper>().Construct();
        }
        
    }
}