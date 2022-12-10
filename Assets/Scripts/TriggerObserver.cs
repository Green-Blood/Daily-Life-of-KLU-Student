using System;
using UnityEngine;

public class TriggerObserver : MonoBehaviour
{
    public Action<Collider2D> OnEnter;
    public Action<Collider2D> OnExit;

    private void OnTriggerEnter2D(Collider2D other) => OnEnter?.Invoke(other);
    private void OnTriggerExit2D(Collider2D other) => OnExit?.Invoke(other);
}