using System;
using Characters.Player;
using Core;
using Dossamer.Dialogue;
using Dossamer.Dialogue.Schema;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameTrigger : MonoBehaviour
{
    [SerializeField] private TriggerObserver triggerObserver;
    [SerializeField] private Cutscene cutscene;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private State triggerState = State.TomCanStart;
    [SerializeField] private State stateToStart = State.TomStart;


    private StateMachine _stateMachine;

    public void Construct(StateMachine stateMachine) => _stateMachine = stateMachine;

    private void OnEnable()
    {
        triggerObserver.OnEnter += OnPlayerEnter;
        playerInput.actions["Fire"].performed += Onperformed;
    }

    private void Onperformed(InputAction.CallbackContext obj)
    {
        DialogueManager.Instance.ProgressDialogue(obj);
    }

    private void OnPlayerEnter(Collider2D other)
    {
        if (!other.TryGetComponent<PlayerBootstrap>(out var playerBootstrap)) return;
        if (_stateMachine.CurrentState == triggerState)
        {
            _stateMachine.Enter(stateToStart);
            DialogueManager.Instance.StartNewDialogue(cutscene);
        }
    }


    private void OnDisable() => triggerObserver.OnEnter -= OnPlayerEnter;
}