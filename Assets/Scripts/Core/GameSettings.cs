using UnityEngine;

namespace Core
{
    [CreateAssetMenu(menuName = "Settings/Create GameSettings", fileName = "GameSettings", order = 0)]
    public class GameSettings : ScriptableObject
    {
        public float tomSpawnDelay = 2f;
    }
}