using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Bird bird;
    public GameObject[] blockPrefabs;

    public float maximumSpawnDistance = 30f;

    public TextMesh infoText;

    private float spawnPointer = 0f;
    private float gameOverTimer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        spawnPointer = maximumSpawnDistance/3;
    }

    // Update is called once per frame
    void Update()
    {
        if (bird.transform.position.z + maximumSpawnDistance > spawnPointer)
        {
            GameObject blockPrefab = blockPrefabs[Random.Range(0, blockPrefabs.Length)];
            GameObject blockObject = Instantiate(blockPrefab);
            blockObject.transform.position = new Vector3(0, 0, spawnPointer);

            spawnPointer += blockObject.GetComponent<Block>().size;
        }
        if (bird.dead == false)
        {
            infoText.text = "Score: " + Mathf.FloorToInt(bird.transform.position.z);
        }
        else
        {
            infoText.text = "Game Over!\nFinal score: " + Mathf.FloorToInt(bird.transform.position.z);

            gameOverTimer = Time.deltaTime;
            if (gameOverTimer <= 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
