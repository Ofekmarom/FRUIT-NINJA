using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    // prefab for the fruit object to spawn
    public GameObject fruitPrefab;
    // array of spawn points where fruits will appear
    public Transform[] spawnPoints;

    // minimum and maximum delay between spawns
    public float minDelay = .1f;
    public float maxDelay = 1f;

    // called once during initialization
    void Start()
    {
        // start the coroutine that spawns fruits continuously
        StartCoroutine(SpawnFruits());
    }

    // coroutine to spawn fruits at random intervals and positions
    IEnumerator SpawnFruits()
    {
        // infinite loop to keep spawning fruits
        while (true)
        {
            // wait for a random amount of time between the min and max delay
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            // choose a random spawn point from the array
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            // instantiate a fruit at the chosen spawn point
            GameObject spawnedFruit = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
            // destroy the spawned fruit after 5 seconds to prevent memory overflow
            Destroy(spawnedFruit, 5f);
        }
    }
}
