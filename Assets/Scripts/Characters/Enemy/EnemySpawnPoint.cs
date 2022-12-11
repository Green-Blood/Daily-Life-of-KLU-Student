using System;
using System.Collections.Generic;
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
        private bool _canSpawn = true;
        private List<GameObject> _spawnedEnemy;

        public void Construct(ObjectPooler objectPooler, Transform playerTransform)
        {
            _objectPooler = objectPooler;
            _playerTransform = playerTransform;
            _spawnedEnemy = new List<GameObject>();
        }

        public void SpawnTom(float spawnDelay)
        {
            Observable.Timer(TimeSpan.FromSeconds(spawnDelay)).Subscribe((l =>
            {
                var enemy = _objectPooler.SpawnFromPool(enemyTag, transform.position, Quaternion.identity);
                enemy.GetComponent<TomBootstrap>().Construct(_playerTransform);
            }));
        }
        public void SpawnMathias(float gameSettingsTomSpawnDelay)
        {
            Observable.Timer(TimeSpan.FromSeconds(gameSettingsTomSpawnDelay)).Subscribe((l =>
            {
                var enemy = _objectPooler.SpawnFromPool(enemyTag, transform.position, Quaternion.identity);
                enemy.GetComponent<MathiasBootstrap>().Construct(_playerTransform);
            }));
        }

        public void SpawnEnemy()
        {
            Observable.Timer(TimeSpan.FromSeconds(4)).Repeat().Subscribe((l =>
            {
                if (!_canSpawn) return;
                var enemy = _objectPooler.SpawnFromPool(enemyTag, transform.position, Quaternion.identity);
                var enemyBootstrap = enemy.GetComponent<EnemyBootstrap>();
                enemyBootstrap.Construct(_playerTransform);
                _spawnedEnemy.Add(enemy);
            }));
        }

        public void DespawnSpawnedEnemy()
        {
            foreach (var spawnedEnemy in _spawnedEnemy)
            {
                spawnedEnemy.SetActive(false);
            }
            _spawnedEnemy.Clear();
        }

        public void StopSpawn() => _canSpawn = false;
        public void AllowSpawn() => _canSpawn = true;

       
    }
}