using UnityEngine;

[System.Serializable]
public struct FloatRange
{
    public float min;
    public float max;

    public readonly float GetRandom()
    {
        return Random.Range(min, max);
    }
}
