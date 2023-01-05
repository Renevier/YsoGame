using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [SerializeField] private GameObject chunk;

    private List<GameObject> chunks = new List<GameObject>();

    private void OnEnable()
    {
        ChunkGenerator.OnChunkCreated += AddChunks;
    }

    void Start()
    {
        chunks.Add(chunk);

        for(int i = 0; i < 2; i++)
            AddChunks();
    }

    void Update()
    {
        
    }

    void AddChunks()
    {
        GameObject go = Instantiate(chunk, chunks[chunks.Count - 1].transform.position + new Vector3(0.0f, chunks[chunks.Count - 1].transform.localScale.y, 0.0f), Quaternion.identity);
        chunks.Add(go);
    }

    private void OnDisable()
    {
        ChunkGenerator.OnChunkCreated -= AddChunks;
    }
}
