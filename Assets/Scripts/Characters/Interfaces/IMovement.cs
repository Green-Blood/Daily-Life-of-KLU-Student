using UnityEngine;

namespace Player
{
    public interface IMovement
    {
        void Move();
        Vector3 Direction { get; }
    }
}