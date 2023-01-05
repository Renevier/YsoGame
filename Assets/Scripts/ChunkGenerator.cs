using System;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    public static event Action OnChunkCreated;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            OnChunkCreated?.Invoke();
    }
}
