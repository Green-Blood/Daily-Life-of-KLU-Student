using Characters.Interfaces;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace Characters.Enemy
{
    public class EnemyDeath : MonoBehaviour, IDie
    {
        [SerializeField] private MMF_Player deathFeedback;
        [SerializeField] private MMF_Player followFeedback;
        
        public void Die()
        {
            // TODO Die logic
            followFeedback.StopFeedbacks();
            deathFeedback.PlayFeedbacks();
            
        }
    }
}