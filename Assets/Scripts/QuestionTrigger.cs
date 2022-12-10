using System;
using Characters.Player;
using UnityEngine;

public class QuestionTrigger : MonoBehaviour
{
    [SerializeField] private int damage = 25;
    
    public bool isCorrect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerBootstrap>(out var player))
        {
            if (isCorrect)
            {
                // ShowCorrect 
            }
            else
            {
                player.PlayerHealth.TakeDamage(damage);
            }
            
        }
    }
}