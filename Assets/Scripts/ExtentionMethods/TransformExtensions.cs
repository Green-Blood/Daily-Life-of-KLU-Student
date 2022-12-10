using UnityEngine;

namespace ExtentionMethods
{
        public static class TransformExtensions 
        {
                public static Vector3 DirectionTo(this Transform source, Transform destination)
                {
                        return source.position.DirectionTo(destination.position);
                }
        }
}
