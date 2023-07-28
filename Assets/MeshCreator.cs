using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCreator : MonoBehaviour
{
    [SerializeField] private MeshFilter _curMesh;
    
    // Start is called before the first frame update
    void Start()
    {
        Create();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Create()
    {
        Vector3[] curVertices = _curMesh.mesh.vertices;


        Vector3[] newVertices = new Vector3[curVertices.Length + 4];


        curVertices.CopyTo(newVertices, 0);


        newVertices[curVertices.Length] = new Vector3(-0.5f, -0.5f, 0);
        newVertices[curVertices.Length + 1] = new Vector3(-0.5f, 0.5f, 0);
        newVertices[curVertices.Length + 2] = new Vector3(-0.25f, -0.5f, 0);
        newVertices[curVertices.Length + 3] = new Vector3(-0.25f, 0.5f, 0);
        
        Mesh newMesh = new Mesh();
        newMesh.vertices = newVertices;
        newMesh.triangles = _curMesh.mesh.triangles;
        newMesh.RecalculateNormals();
    }
}
