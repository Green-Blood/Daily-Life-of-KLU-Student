using System;
using Characters.Player;
using Core;
using UnityEngine;

public class GameTrigger : MonoBehaviour
{
    [SerializeField] private TriggerObserver triggerObserver;

    private StateMachine _stateMachine;

    public void Construct(StateMachine stateMachine) => _stateMachine = stateMachine;
    private void OnEnable() => triggerObserver.OnEnter += OnPlayerEnter;

    private void OnPlayerEnter(Collider2D other)
    {
        if (!other.TryGetComponent<PlayerBootstrap>(out var playerBootstrap)) return;
        if (_stateMachine.CurrentState == State.TomCanStart) _stateMachine.Enter(State.TomStart);
    }

    private void OnDisable() => triggerObserver.OnEnter -= OnPlayerEnter;
}