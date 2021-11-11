using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Bird bird;
    public GameObject[] blockPrefabs;

    public float maximumSpawnDistance = 30f;

    private float spawnPointer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bird.transform.position.z + maximumSpawnDistance > spawnPointer)
        {
            GameObject blockPrefab = blockPrefabs[Random.Range(0, blockPrefabs.Length)];
            GameObject blockObject = Instantiate(blockPrefab);
            blockObject.transform.position = new Vector3(0, 0, spawnPointer);

            spawnPointer += blockObject.GetComponent<Block>().size;
        }
    }
}
