using System;
using Core;
using ExtentionMethods.Object_Pooler;
using UniRx;
using UnityEngine;

namespace Characters.Enemy
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        [SerializeField] private Tag enemyTag;
        private ObjectPooler _objectPooler;
        private Transform _playerTransform;
        private EnemySettings _enemySettings;
        private bool _canSpawn;

        public void Construct(ObjectPooler objectPooler, Transform playerTransform)
        {
            _objectPooler = objectPooler;
            _playerTransform = playerTransform;
        }

        public void SpawnTom(float spawnDelay )
        {
            Observable.Timer(TimeSpan.FromSeconds(spawnDelay)).Subscribe((l =>
            {
                var enemy = _objectPooler.SpawnFromPool(enemyTag, transform.position, Quaternion.identity);
                enemy.GetComponent<TomBootstrap>().Construct(_playerTransform);
            }));
            
        }

        public void SpawnEnemy()
        {
            var observable = Observable.Timer(TimeSpan.FromSeconds(4)).Repeat().Subscribe((l =>
            {
                if(!_canSpawn) return;
                var enemy = _objectPooler.SpawnFromPool(enemyTag, transform.position, Quaternion.identity);
                enemy.GetComponent<EnemyBootstrap>().Construct(_playerTransform);
            }));
        }

        public void StopSpawn() => _canSpawn = false;
        public void AllowSpawn() => _canSpawn = true;
    }
}