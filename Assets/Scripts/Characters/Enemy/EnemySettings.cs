using Characters.Player;
using UnityEngine;

namespace Characters.Enemy
{
    [CreateAssetMenu(menuName = "Settings/Create EnemySettings", fileName = "EnemySettings", order = 0)]
    public class EnemySettings : CharacterSettings
    {
        public float attackCooldown = 1f;
        public float attackDistance = 1f;
        public float attackRadius = 0.5f;
        public int attackDamage = 10;
        public LayerMask pLayerMask;
        public float spawnCooldown = 3f;
    }
}