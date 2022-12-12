using System;
using Characters.Interfaces;
using MoreMountains.Feedbacks;
using UniRx;
using UnityEngine;

namespace Characters.Player
{
    public class PlayerDeath : MonoBehaviour, IDie
    {
        [SerializeField] private SceneSwitcher sceneSwitcher;
        [SerializeField] private MMF_Player playerDeathFeedback;
        
        public void Die()
        {
            playerDeathFeedback.PlayFeedbacks();
      
            Observable.Timer(TimeSpan.FromSeconds(3f)).Subscribe((l =>
            {
                sceneSwitcher.Death();
            }));
        }
    }
}