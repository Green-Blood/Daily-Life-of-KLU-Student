using Characters.Player;
using UnityEngine;

namespace Characters.Enemy
{
    [CreateAssetMenu(menuName = "Settings/Create EnemySettings", fileName = "EnemySettings", order = 0)]
    public class EnemySettings : CharacterSettings
    {
        public float attackCooldown = 1f;
    }
}