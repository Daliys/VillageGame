using UnityEngine;

namespace ItemResources
{
    public interface IGatherable
    {
         public Vector3 GetPosition();
         public float GetTimeToGather();
    }
}