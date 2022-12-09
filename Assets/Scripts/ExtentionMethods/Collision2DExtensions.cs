using System.Linq;
using UnityEngine;

namespace Extensions
{
    public static class Collision2DExtensions
    {
        public static float GetImpactForce(this Collision2D collision)
        {
            float impulse = collision.contacts.Sum(point => point.normalImpulse);
            return impulse / Time.fixedDeltaTime;
        }
    }
}