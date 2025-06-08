using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;

    public float spawnRate = 2f;
    public float heightOffset = 2f;

    private float timer = 0;

    void Start()
    {
        SpawnPipe();
    }

    void Update()
    {
        if (GameManager.Instance.IsGameOver) return;

        if (timer > spawnRate)
        {
            SpawnPipe();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    void SpawnPipe()
    {
        // Randomly pick between top (3) and bottom (-3)
        float y = Random.Range(0f, 1f) > 0.5f ? 3f : -3f;

        // Set rotation based on y value
        float rotation = (y == 3f) ? 180f : 0f;

        // Randomize the height of the pipe (scale between 7 and 10)
        float pipeHeight = Random.Range(7f, 9f);

        // Create the spawn position
        Vector3 spawnPos = new Vector3(10, y, 0);
        GameObject pipe = Instantiate(pipePrefab, spawnPos, Quaternion.Euler(0, 0, rotation));

        // Adjust the scale of the pipe based on randomized height
        pipe.transform.localScale = new Vector3(1f, pipeHeight, 1f);
    }
}