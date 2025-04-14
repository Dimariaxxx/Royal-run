using System;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Random = Unity.Mathematics.Random;
using Vector3 = UnityEngine.Vector3;

public class LevelGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Referencies")]
    [SerializeField] GameObject[] chunkPrefab;
    [SerializeField] CameraController cameraController;
    [SerializeField] Transform chunkParent;
    [SerializeField] ScoreManager scoreManager;
    [Header("Level Settings")]

    [SerializeField] int chunksAmount=10;
    [Tooltip("Do not change shift before prefab will be resized")]
    [SerializeField] float shift=10f;
    [SerializeField] float minSpeed=2f;
    [SerializeField] float maxSpeed=20f;
    [SerializeField] float minGravity=-22f;
    [SerializeField] float maxGravity=-2f;
    [SerializeField] float speed=0.008f;
    BigInteger spawnedChunks=0;
    //GameObject[] chunks;
    List<GameObject> chunks=new List<GameObject>();
    void Start()
    {      
        //chunks=new GameObject[chunksAmount];
        SpawnChunks();
    }
    void Update()
    {
        MoveChunks();
    }

    private void SpawnChunks()
    {
        for (int i = 0; i < chunksAmount; i++)
        {
            CalculateAndAdd(i, 0);
        }
    }

    private void CalculateAndAdd(int i, int b )
    {
        Vector3 curPos = new UnityEngine.Vector3(transform.position.x, transform.position.y, transform.position.z + shift * (chunks.Count-b));
        int chunkIndex;//index for chunk variants massive
        if((spawnedChunks%8)==0)chunkIndex=3;
        else chunkIndex=UnityEngine.Random.Range(0, chunkPrefab.Length-1);
        GameObject newChunk = Instantiate(chunkPrefab[chunkIndex], curPos, quaternion.identity, chunkParent);
        chunks.Add(newChunk);
        spawnedChunks++;
        Debug.Log(spawnedChunks);
        newChunk.GetComponent<Chunk>().Init(scoreManager);
    }

    void MoveChunks()
    {
        for (int i = 0; i < chunks.Count; i++)
        {   
            GameObject chunk=chunks[i];
            chunk.transform.Translate(-transform.forward*speed*Time.deltaTime);
            if(chunk.transform.position.z<=Camera.main.transform.position.z-shift)
            {
                Destroy(chunk);
                chunks.Remove(chunk);
                CalculateAndAdd(i, 1);
            }
        }
    }
    public void ChangeChunkMoveSpeed(float speedAmount)
    {
        /*speed+=speedAmount;
        if(speed<minSpeed)
        {
            speed=minSpeed;
        }
        Physics.gravity=new Vector3(Physics.gravity.x, Physics.gravity.y, Physics.gravity.z-speedAmount);

        cameraController.ChangeCamerFOV(speedAmount);
    }*/
    float newMoveSpeed = speed + speedAmount;
        newMoveSpeed = Mathf.Clamp(newMoveSpeed, minSpeed, maxSpeed);

        if (newMoveSpeed != speed) 
        {
            speed = newMoveSpeed;

            float newGravityZ = Physics.gravity.z - speedAmount;
            newGravityZ = Mathf.Clamp(newGravityZ, minGravity, maxGravity);
            Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, newGravityZ);
            
            cameraController.ChangeCamerFOV(speedAmount);
        }
    }

}
