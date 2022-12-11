using System;
using Characters.Player;
using UnityEngine;

public class QuestionTrigger : MonoBehaviour
{
    [SerializeField] private int damage = 25;
    
    public bool isCorrect;
    public Action OnCorrectQuestionTriggered;
    public Action OnInCorrectQuestionTriggered;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent<PlayerBootstrap>(out var player)) return;
        if (isCorrect)
        {
            OnCorrectQuestionTriggered?.Invoke();
        }
        else
        {
            player.PlayerHealth.TakeDamage(damage);
            OnInCorrectQuestionTriggered?.Invoke();
        }
    }
}