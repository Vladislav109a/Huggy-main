using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneratore : MonoBehaviour
{
    [SerializeField] private GameObject[] tilePrefabs;
    private List<GameObject> activeTiles = new List<GameObject>();
    private float spawnPos = 0;
    private float tileLength = 32.5f;

    [SerializeField] Transform player;

    
    private int startTiles = 6;
    private void Start()
    {
        for (int i = 0; i < startTiles; i++)
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
    }
    private void Update()
    {
        if (player.position.z -60> spawnPos - (startTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }
    private void SpawnTile(int tileIndex)
    {
        GameObject newTile = Instantiate(tilePrefabs[tileIndex], transform.forward * spawnPos, transform.rotation);
        activeTiles.Add(newTile);
        spawnPos += tileLength;
    }
    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
