using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Road))]
public class RoadEditor : Editor
{
    //Parameters
    private Road road = null;

    //Methods
    private void OnEnable()
    {
        road = target as Road;
    }
    private void OnSceneGUI()
    {
        Vector3[] points = road.points;
        Vector3 snap = Vector3.one * 0.5f;

        EditorGUI.BeginChangeCheck();

        for(int i = 0; i < points.Length; i ++)
        {
            points[i] = Handles.FreeMoveHandle(points[i], Quaternion.identity, 5f, snap, Handles.SphereHandleCap);
        }

        for(int i = 3; i < points.Length; i ++) 
        { 
            Vector3 pA = points[i - 3];
            Vector3 pAc = points[i - 2];

            Vector3 pB = points[i];
            Vector3 pBc = points[i - 1];

            Handles.DrawBezier(pA, pB, pAc, pBc, Color.red, EditorGUIUtility.whiteTexture, 1f);
        }

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(road, "Change Points Position");
            road.points = points;
            road.Update();
        }
    }
}
