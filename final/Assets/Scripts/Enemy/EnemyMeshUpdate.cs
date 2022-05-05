using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeshUpdate : MonoBehaviour
{
    SkinnedMeshRenderer meshRenderer;
    MeshCollider meshCollider;
    void Awake()
    {
        meshRenderer = gameObject.GetComponent<SkinnedMeshRenderer>();
        meshCollider = gameObject.GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Mesh newMesh = new Mesh();
        meshRenderer.BakeMesh(newMesh);
        meshCollider.sharedMesh = newMesh;

    }
    void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
    }
}
