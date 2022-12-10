using Characters;
using Characters.Player;
using UnityEngine;

namespace Core
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] private HealthBar healthBar;

        public void Construct(PlayerBootstrap playerBootstrap)
        {
            healthBar.Construct(playerBootstrap.PlayerHealth);
        }
        
    }
}