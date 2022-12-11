using Characters.Interfaces;
using UnityEngine;

namespace Characters.Player
{
    public class PlayerDeath : MonoBehaviour, IDie
    {
        [SerializeField] private SceneSwitcher sceneSwitcher;
        
        public void Die()
        {
            sceneSwitcher.Death();
        }
    }
}