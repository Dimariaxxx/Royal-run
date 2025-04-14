using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Chunk : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] float[] lanes={-2.5f, 0f, 2.5f};
    [SerializeField] float  appleSpawnChance=.3f, coinSpawnChance=.5f;
    [SerializeField] int coinCount=5;
    ScoreManager scoreManager;

    List<int> availableLanes=new List<int>{0,1,2};
    void Start()
    {
        SpawnFence();
        SpawnApple();
        SpawnCoins();
    }
    public void Init(ScoreManager scoreManager)
    {
        this.scoreManager=scoreManager;
    }

    void SpawnFence()
    {
        int fencesToSpawn=Random.Range(0, lanes.Length);
        for(int i=0; i<fencesToSpawn; i++)
        {
            if (availableLanes.Count <= 0) break;
            int selectedLane = SelectLane();
            Vector3 spawnPos = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPos, quaternion.identity, transform);
        }
    }



    void SpawnApple()
    {
        if(Random.value>appleSpawnChance || availableLanes.Count<=0) return;
        int selectedLane = SelectLane();
        Vector3 spawnPos = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        Instantiate(applePrefab, spawnPos, quaternion.identity, transform);
    }
      void SpawnCoins()
    {
        if(Random.value>coinSpawnChance || availableLanes.Count<=0) return;
        int selectedLane = SelectLane();
        int loopCount=Random.Range(1,coinCount);
        for(int i=0; i<loopCount; i++)
        {
        float zPos=transform.position.z-3f+6f/loopCount*i;
        Vector3 spawnPos = new Vector3(lanes[selectedLane], transform.position.y, zPos);
        Coin newCoin=Instantiate(coinPrefab, spawnPos, quaternion.identity, transform).GetComponent<Coin>();
        newCoin.Init(scoreManager);
        }
    }
    


    int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[randomLaneIndex];
        availableLanes.RemoveAt(randomLaneIndex);
        return selectedLane;
    }
}
