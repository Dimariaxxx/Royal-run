using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject[] obstaclePredabs;
    [SerializeField] float waitSeconds=1f;
    [SerializeField] Transform obstacleParent;
    [SerializeField] float spawnWidth=4f;
    void Start()
    {
        StartCoroutine("SpawnObstacleRoutine");
    }
    IEnumerator SpawnObstacleRoutine()
    {
        while(true)
        {
            GameObject obstaclePredab=obstaclePredabs[Random.Range(0, obstaclePredabs.Length)];
            Vector3 spawnPos=new Vector3(transform.position.x+Random.Range(-spawnWidth, spawnWidth),transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitSeconds);
            Instantiate(obstaclePredab, spawnPos, Random.rotation,obstacleParent);
            
        }
    }
}
