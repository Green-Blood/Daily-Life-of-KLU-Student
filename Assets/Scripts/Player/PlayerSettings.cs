using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "Settings/Create Player Settings", fileName = "PlayerSettings", order = 0)]
    public class PlayerSettings : ScriptableObject
    {
        public float playerSpeed;
    }
}