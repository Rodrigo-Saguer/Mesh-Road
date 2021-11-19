using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Interpolations 
{ 
    public static Vector3 QuadraticLerp(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        Vector3 pA = Vector3.Lerp(a, b, t);
        Vector3 pB = Vector3.Lerp(b, c, t);

        return Vector3.Lerp(pA, pB, t);
    }

    public static Vector3 CubicLerp(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
    {
        Vector3 pA = QuadraticLerp(a, b, c, t);
        Vector3 pB = QuadraticLerp(b, c, d, t);

        return Vector3.Lerp(pA, pB, t);
    }
}
