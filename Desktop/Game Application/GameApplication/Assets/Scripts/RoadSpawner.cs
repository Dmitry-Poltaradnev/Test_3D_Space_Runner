using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject[] RoadBloksPrefab;
    public GameObject StartBlock;

    float blockXpos = 0;          
    int blocksCount = 7;
    float blocksLenght = 0;
    int saveZone = 50;



    public Transform PlayerTransf;
    List<GameObject> CurrentBlocks = new List<GameObject>();

    Vector3 startPlayerPos;

    void Start()
    {
        blockXpos = StartBlock.transform.position.x;
        blocksLenght = StartBlock.GetComponent<BoxCollider>().bounds.size.x;

        CurrentBlocks.Add(StartBlock);

        for (int i = 0; i < blocksCount; i++)
            SpawnBlock();
    }  



    void Update()
    {
        CheckForSpaun();
    }


    void CheckForSpaun()
    {
        if (PlayerTransf.position.x - saveZone > (blockXpos - blocksCount * blocksLenght))
        {
            SpawnBlock();
            DestroyBlock();
        }

    }


    void SpawnBlock()
    {

        GameObject block = Instantiate(RoadBloksPrefab[Random.Range(0, RoadBloksPrefab.Length)], transform);


        blockXpos += blocksLenght;

        block.transform.position = new Vector3(blockXpos, 0, 0);

        CurrentBlocks.Add(block);
    }

    void DestroyBlock()
    {
        Destroy(CurrentBlocks[0]);
        CurrentBlocks.RemoveAt(0);
    }
}
