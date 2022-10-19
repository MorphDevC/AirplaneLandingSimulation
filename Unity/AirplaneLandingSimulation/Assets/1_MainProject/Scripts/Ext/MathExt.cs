using UnityEngine;

public static class MathExt
{
    public static float Tan(this float targetClass)
    {
        return Mathf.Tan((targetClass * (Mathf.PI)) / 180);
    }
}
