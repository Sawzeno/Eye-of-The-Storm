using System;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
public class Env : MonoBehaviour

{
    // int 
    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;


    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        CreateShape();
        UpdateMesh();
    }

    public void CreateShape()
    {
        
        int i = 0;
        int j = 0;
        // int k = 0;
        Vector3 a = new Vector3(0, 0, 0);
        Vector3 b = new Vector3(0, 0, 1);

        for (int k = 0; k < MakeVertices(8).Length; k++)
        {
            Debug.Log(MakeVertices(8)[k]);
        }

        vertices = MakeVertices(8);
        triangles = new int[]
        {
            0, 1, 2,
            1, 3, 2,
            2, 3, 4,
            3, 5, 4,
            4, 5, 6,
            5, 7, 6,
        };
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }

    Vector3[] MakeVertices(int n)
    {
        Vector3 a = new Vector3(0, 0, 0);
        Vector3 b = new Vector3(0, 0, 1);
        Vector3[] c = new Vector3[n + 2];
        c[0] = a;
        c[1] = b;
        for (int i = 2; i < c.Length; i += 2)
        {
            c[i] = new Vector3(i / 2, 0, 0);
            c[i + 1] = c[i] + new Vector3(0, 0, 1);
        }  

        return c;
    }

    int[] MakeTriangles(int n)
    {
        int a = 0;
        int b = 1;
        int c = 2;
        int[] d = new int[n];


        return d;
    }

    private void OnDrawGizmos()
    {
        if (vertices == null)
        {
            return;
        }

        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], .1f);
        }
    }
}