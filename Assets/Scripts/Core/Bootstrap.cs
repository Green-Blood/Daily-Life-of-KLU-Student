using System;
using Characters.Enemy;
using Characters.Player;
using ExtentionMethods.Object_Pooler;
using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        private StateMachine _stateMachine;
        [SerializeField] private PlayerBootstrap playerBootstrap;
        [SerializeField] private EnemySpawnPoint[] enemySpawnPoints;
        [SerializeField] private GameTrigger[] gameTriggers;
        [SerializeField] private ObjectPooler objectPooler;
        [SerializeField] private GameCanvas gameCanvas;


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

            // TODO Change it with the game state 
            playerBootstrap.StartPlayer();
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

        private void OnStateChange(State state)
        {
            switch (state)
            {
                case State.GameStart:
                    break;
                case State.GameEnd:
                    break;
                case State.GameFinish:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }
}