using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnZ = 30f;
    public float minInterval = 1.0f;
    public float maxInterval = 2.0f;
    public float laneX = 0f;
    public float spawnY = 0.5f;

    bool spawning = true;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (spawning)
        {
            SpawnOne();
            float wait = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(wait);
        }
    }

    void SpawnOne()
    {
        Vector3 pos = new Vector3(laneX, spawnY, transform.position.z + spawnZ);
        Instantiate(obstaclePrefab, pos, Quaternion.identity);
    }

    public void StopSpawning() => spawning = false;

    public void StartSpawning()
    {
        spawning = true;
        StopAllCoroutines();
        StartCoroutine(SpawnLoop());
    }
}
