using System;
using Characters.Enemy;
using Characters.Player;
using ExtentionMethods.Object_Pooler;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [BoxGroup("SpawnPoints")] [SerializeField]
        private EnemySpawnPoint[] enemySpawnPoints;

        [BoxGroup("SpawnPoints")] [SerializeField]
        private EnemySpawnPoint tomSpawnPoint;

        [BoxGroup("UI")] [SerializeField] private GameCanvas gameCanvas;

        [BoxGroup("Game Scripts")] [SerializeField]
        private PlayerBootstrap playerBootstrap;

        [BoxGroup("Game Scripts")] [SerializeField]
        private GameTrigger[] gameTriggers;

        [BoxGroup("Game Scripts")] [SerializeField]
        private ObjectPooler objectPooler;

        [BoxGroup("Settings")] [SerializeField]
        private GameSettings gameSettings;


        private StateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = new StateMachine();
        }

        private void Start()
        {
            InitStateMachine();
            ConstructPlayer();
            ConstructEnemies();
            ConstructTriggers();

            gameCanvas.Construct(playerBootstrap);
            tomSpawnPoint.Construct(objectPooler, playerBootstrap.transform);

            // TODO Change it with the game state 
            playerBootstrap.StartPlayer();
            _stateMachine.Enter(State.TomCanStart);
        }

        private void OnStateChange(State state)
        {
            switch (state)
            {
                case State.TomStart:
                    StopEnemies();
                    StartTom();

                    break;
                case State.TomEnd:
                    StartEnemies();

                    break;
            }
        }

        private void StartTom()
        {
            tomSpawnPoint.SpawnTom(gameSettings.tomSpawnDelay);
        }


        private void StopEnemies()
        {
            foreach (var enemySpawnPoint in enemySpawnPoints)
            {
                enemySpawnPoint.StopSpawn();
                enemySpawnPoint.DespawnSpawnedEnemy();
            }
        }

        private void StartEnemies()
        {
            foreach (var enemySpawnPoint in enemySpawnPoints)
            {
                enemySpawnPoint.AllowSpawn();
            }
        }

        private void ConstructEnemies()
        {
            foreach (var enemySpawnPoint in enemySpawnPoints)
            {
                enemySpawnPoint.Construct(objectPooler, playerBootstrap.transform);
                // TODO Change it to the right place
                enemySpawnPoint.SpawnEnemy();
            }
        }

        private void ConstructTriggers()
        {
            foreach (var gameTrigger in gameTriggers)
            {
                gameTrigger.Construct(_stateMachine);
            }
        }

        private void ConstructPlayer() => playerBootstrap.Construct(objectPooler);

        private void InitStateMachine()
        {
            _stateMachine.OnStateChange += OnStateChange;
            _stateMachine.Enter(State.GameStart);
        }
    }
}