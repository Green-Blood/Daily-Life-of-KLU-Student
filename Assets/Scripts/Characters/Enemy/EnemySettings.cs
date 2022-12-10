using UnityEngine;

namespace Characters.Enemy
{
    [CreateAssetMenu(menuName = "Settings/Create EnemySettings", fileName = "EnemySettings", order = 0)]
    public class EnemySettings : ScriptableObject
    {
        public int health;
    }
}