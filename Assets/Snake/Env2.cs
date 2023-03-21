using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Env2 : MonoBehaviour
{
    [SerializeField] private int xSize = 20;
    [SerializeField] private int zSize = 20;
    [SerializeField] private int yRandom = 10;
    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;

    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        // StartCoroutine(CreateShape());
        CreateShape();
    }

    private void Update()
    {
        UpdateMesh();
    }

    // private IEnumerator CreateShape()
    private void CreateShape()
    {
        CreateVertices();
        CreateTriangles();
        // yield return new WaitForSeconds(0.1f);
    }

    private Vector3[] CreateVertices()
    {
        Vector3[] c = new Vector3[(xSize + 1) * (zSize + 1)];
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                c[i] = new Vector3(x, 0, z);
                Debug.Log(c[i]);
                i++;
            }
        }

        vertices = c;
        return vertices;
    }

    private int[] CreateTriangles()
    {
        int vert = 0;
        int tris = 0;
        int[] c = new int[xSize * zSize * 6];
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                c[tris + 0] = vert + 0;
                c[tris + 1] = vert + xSize + 1;
                c[tris + 2] = vert + 1;
                c[tris + 3] = vert + 1;
                c[tris + 4] = vert + xSize + 1;
                c[tris + 5] = vert + xSize + 2;
                vert++;
                tris += 6;
            }
            vert++;
        }

        triangles = c;
        return triangles;
    }


    private void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    private void OnDrawGizmos()
    {
        if (vertices == null)
        {
            return;
        }

        foreach (var t in vertices)
        {
            Gizmos.DrawSphere(t, .1f);
        }
    }
}