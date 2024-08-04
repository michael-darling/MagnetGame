using UnityEngine;

[System.Serializable]
public struct FloatRange
{
    public float min;
    public float max;

    public FloatRange(float min, float max)
    {
        this.min = min; this.max = max;
    }

    public readonly float GetRandom()
    {
        return Random.Range(min, max);
    }
}
