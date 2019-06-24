using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject GOToSpawn;
    static int entityToSpawnAmount;

    Vector3 spawnPosition;
    public int maxSpawnPositionOffset;

    public float initialSpawnTimer;
    public float spawnTimer;
    public float maxTimerOffset;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = initialSpawnTimer+UnityEngine.Random.Range(-maxTimerOffset, maxTimerOffset);
        spawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer<=0)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        GameObject go = Instantiate(GOToSpawn);
        go.transform.position = spawnPosition + new Vector3(UnityEngine.Random.Range(-maxSpawnPositionOffset, maxSpawnPositionOffset), 0, UnityEngine.Random.Range(-maxSpawnPositionOffset, maxSpawnPositionOffset));
        spawnTimer = initialSpawnTimer + UnityEngine.Random.Range(-maxTimerOffset, maxTimerOffset);
    }
}
