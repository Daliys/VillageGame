using UnityEngine;
using Villanger;

public class FoodGatherable : MonoBehaviour, IGatherable
{
    public Vector3 GetPosition()
    {
        return gameObject.transform.position;
    }

    public float GetTimeToGather()
    {
        return 10f;
    }
}