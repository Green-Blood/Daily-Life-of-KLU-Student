using UnityEngine;

namespace Characters.Interfaces
{
    public interface IMovement
    {
        void Move();
        Vector3 Direction { get; }
    }
}