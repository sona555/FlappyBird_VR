using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Bird bird;
    public GameObject[] blockPrefabs;
    public GameObject coin;

    public float maximumSpawnDistance = 30f;

    public TextMesh infoText;
    public TextMesh coinText;

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
            GameObject reward = Instantiate(coin);
            blockObject.transform.position = new Vector3(0, 0, spawnPointer);
            reward.transform.position = new Vector3(0, blockObject.transform.position.y + Random.Range(3, 5), Random.Range(0, 10.0f) * spawnPointer);

            spawnPointer += blockObject.GetComponent<Block>().size;
        }
        if (bird.dead == false)
        {
            infoText.text = "Score: " + Mathf.FloorToInt(bird.transform.position.z) + "\nCoins: " + bird.coins;
        }
        else
        {
            infoText.text = "\nGame Over!\nScore: " + Mathf.FloorToInt(bird.transform.position.z)+"\nCoins: " + bird.coins;

            gameOverTimer = Time.deltaTime;
            if (gameOverTimer <= 0f)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
