using UnityEngine;

namespace Villanger
{
    public interface IGatherable
    {
         public Vector3 GetPosition();
         public float GetTimeToGather();
    }
}