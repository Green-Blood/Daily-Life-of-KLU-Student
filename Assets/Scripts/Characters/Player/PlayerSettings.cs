using UnityEngine;

namespace Characters.Player
{
    [CreateAssetMenu(menuName = "Settings/Create Player Settings", fileName = "PlayerSettings", order = 0)]
    public class PlayerSettings : CharacterSettings
    {
        public int throwDistance = 25;
        public float cupCreationOffset;
        public int cupDamage = 20;
    }
}