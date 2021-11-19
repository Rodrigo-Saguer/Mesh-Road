using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter), typeof(MeshCollider))]
public class Road : MonoBehaviour
{
    //Parameters
    public int quality = 16;
    public float meshScale = 1;

    public Vector3[] points = null;

    private Mesh mesh = null;
    private MeshFilter meshFilter = null;
    private MeshCollider meshCollider = null;
    
    //Methods
    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshCollider = GetComponent<MeshCollider>();
    }

    private void Start()
    {
        Generate();
    }

    public void Update()
    {
        Generate();
    }

    public void Generate()
    {
        if (points == null) return;
        if (points.Length < 4) return;
        if (quality <= 1) return;

        mesh = new Mesh();

        //Generate a bezier curve path using the points array
        Vector3[] topVertices = new Vector3[quality];
        Vector3[] bottomVertices = new Vector3[quality];

        float distance = 1f / (quality - 1);

        for (int i = 0; i < quality; i++)
        {
            topVertices[i] = Interpolations.CubicLerp(points[0], points[1], points[2], points[3], i * distance);
            bottomVertices[i] = topVertices[i] + (Vector3.down * meshScale);
        }

        //Assign vertices
        Vector3[] vertices = new Vector3[quality * 2];

        for (int i = 0; i < quality * 2; i++)
        {
            if (i < quality) vertices[i] = topVertices[i];
            else vertices[i] = bottomVertices[i - quality];
        }

        mesh.vertices = vertices;

        //Generate triangles
        int[] triangles = new int[quality * 2 * 3];

        for (int i = 0; i < quality - 1; i++)
        {
            int v = i * 6;

            triangles[v] = i;
            triangles[v + 1] = i + 1;
            triangles[v + 2] = i + quality;

            triangles[v + 3] = i + 1;
            triangles[v + 4] = i + quality + 1;
            triangles[v + 5] = i + quality;
        }

        mesh.triangles = triangles;

        //Assign mesh
        meshFilter.sharedMesh = mesh;
        meshCollider.sharedMesh = meshFilter.sharedMesh;
    }
}
