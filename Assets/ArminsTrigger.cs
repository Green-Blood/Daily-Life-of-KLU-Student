using System;
using System.Collections;
using System.Collections.Generic;
using Characters.Player;
using UnityEngine;

public class ArminsTrigger : MonoBehaviour
{
    [SerializeField] private TriggerObserver triggerObserver;
    [SerializeField] private AudioSystem audioSystem;

    private void Awake()
    {
        triggerObserver.OnEnter += OnEnter;
        triggerObserver.OnExit += OnExit;
    }

    private void OnEnter(Collider2D other)
    {
        if (other.TryGetComponent<PlayerBootstrap>(out var player))
        {
            audioSystem.StartArmin();
        }
    }
    private void OnExit(Collider2D other)
    {
        if (other.TryGetComponent<PlayerBootstrap>(out var player))
        {
            audioSystem.StartExplore();
        }
    }
}
