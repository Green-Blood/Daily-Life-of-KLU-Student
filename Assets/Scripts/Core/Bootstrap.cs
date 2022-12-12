using System;
using Characters.Enemy;
using Characters.Player;
using ExtentionMethods.Object_Pooler;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [BoxGroup("SpawnPoints")] [SerializeField]
        private EnemySpawnPoint[] enemySpawnPoints;

        [BoxGroup("SpawnPoints")] [SerializeField]
        private EnemySpawnPoint tomSpawnPoint;
        [BoxGroup("SpawnPoints")] [SerializeField]
        private EnemySpawnPoint mathiasSpawnPoint;

        [BoxGroup("UI")] [SerializeField] private GameCanvas gameCanvas;

        [BoxGroup("Game Scripts")] [SerializeField]
        private PlayerBootstrap playerBootstrap;

        [BoxGroup("Game Scripts")] [SerializeField]
        private GameTrigger[] gameTriggers;

        [BoxGroup("Game Scripts")] [SerializeField]
        private ObjectPooler objectPooler;

        [BoxGroup("Settings")] [SerializeField]
        private GameSettings gameSettings;

        [SerializeField] private QuestionTriggers questionTriggers;
        [SerializeField] private SceneSwitcher sceneSwitcher;



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
            mathiasSpawnPoint.Construct(objectPooler, playerBootstrap.transform);
            questionTriggers.Construct(_stateMachine);
            // questionTriggers.Construct(_stateMachine);
            // TODO Change it with the game state 
            playerBootstrap.StartPlayer();
            _stateMachine.Enter(State.TomCanStart);
        }

        public void EndTomsQuestions()
        {
            _stateMachine.Enter(State.MathiasCanStart);
        }

        private void OnStateChange(State state)
        {
            switch (state)
            {
                case State.TomStart:
                    StopEnemies();
                    StartTom();

                    break;
                case State.MathiasCanStart:
                    StartEnemies();
                    break;
                case State.MathiasStart:
                    StopEnemies();
                    StartMathias();
                    break;
                case State.GameEnd:
                    Observable.Timer(TimeSpan.FromSeconds(1f)).Subscribe((l =>
                    {
                        sceneSwitcher.Death();
                    }));
                   
                    break;
            }
        }

        private void StartTom()
        {
            tomSpawnPoint.SpawnTom(gameSettings.tomSpawnDelay);
        }
        private void StartMathias()
        {
            mathiasSpawnPoint.SpawnMathias(gameSettings.tomSpawnDelay);
        }

        public void EndGame()
        {
            
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

        private void ConstructPlayer() => playerBootstrap.Construct(objectPooler, _stateMachine);

        private void InitStateMachine()
        {
            _stateMachine.OnStateChange += OnStateChange;
            _stateMachine.Enter(State.GameStart);
        }
    }
}