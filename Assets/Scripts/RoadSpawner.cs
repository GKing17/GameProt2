using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject[] RoadBlockPref;
    public GameObject StartBlock;

    private float blockXPos = 0;
    private int blocksCount = 7;
    private float blockLength = 0;
    private int safeDistance = 50;

    public Transform PlayerTransform;
    private List<GameObject> CurrentBlocks = new List<GameObject>();
    void Start()
    {
        blockXPos = StartBlock.transform.position.x;
        blockLength = StartBlock.GetComponent<BoxCollider>().bounds.size.x;

        CurrentBlocks.Add(StartBlock);
        for (int i = 0; i < blocksCount; i++)
        {
            SpawnBlock();
        }
        
    }

    void Update()
    {
        CheckForSpawn();
    }

    void CheckForSpawn()
    {
        if (PlayerTransform.position.x - safeDistance > (blockXPos - blocksCount * blockLength))
        {
            SpawnBlock();
            DestroyBlock();
        }
    }
    void SpawnBlock()
    {
        GameObject block = Instantiate(RoadBlockPref[Random.Range(0, RoadBlockPref.Length)], transform);
        
        blockXPos += blockLength;

        block.transform.position = new Vector3(blockXPos,0,0);
        
        CurrentBlocks.Add(block);
    }

    void DestroyBlock()
    {
        Destroy(CurrentBlocks[0]);
        CurrentBlocks.RemoveAt(0);
    }
    
}
