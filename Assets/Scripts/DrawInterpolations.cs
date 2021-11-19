using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawInterpolations : MonoBehaviour
{
    public int quality = 16;
    public Vector3 a;
    public Vector3 b;
    public Vector3 c;
    public Vector3 d;

    private void OnDrawGizmos()
    {
        float dis = 1f / quality;
        Gizmos.DrawSphere(a, 0.25f);
        Gizmos.DrawSphere(b, 0.25f);
        Gizmos.DrawSphere(c, 0.25f);
        Gizmos.DrawSphere(d, 0.25f);

        for (int i = 0; i < quality; i ++)
        {
            Vector3 pA = Interpolations.CubicLerp(a, b, c, d, dis * i);
            Vector3 pB = Interpolations.CubicLerp(a, b, c, d, dis * (i + 1));

            Gizmos.DrawLine(pA, pB);
        }
    }
}
