using ExtentionMethods.Object_Pooler;
using UnityEngine;

namespace Characters.Enemy
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        [SerializeField] private Tag enemyTag;
        private ObjectPooler _objectPooler;
        private Transform _enemyTransform;
        public void Construct(ObjectPooler objectPooler, Transform enemyTransform)
        {
            _objectPooler = objectPooler;
            _enemyTransform = enemyTransform;
        }

        public void SpawnEnemy()
        {
            var enemy = _objectPooler.SpawnFromPool(enemyTag, transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyBootstrap>().Construct(_enemyTransform);
        }
        
    }
}