using Player;
using UnityEngine;

namespace Characters.Enemy
{
    public class EnemyDeath : MonoBehaviour, IDie
    {
        public void Die()
        {
            // TODO Die logic
            gameObject.SetActive(false);
        }
    }
}