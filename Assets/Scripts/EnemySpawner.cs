using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnDelay;
    private float spawnTime;
    public bool random;
    public GameObject enemyPrefab;
    public Direction dir;
    // Start is called before the first frame update
    void Start()
    {
        if (random)
        {
            spawnTime = Random.Range(0.0f, spawnDelay);
        }
        else
        {
            spawnTime = spawnDelay;
        }
    }

        // Update is called once per frame
        void Update()
    {
        spawnTime -= Time.deltaTime;
        if(spawnTime <= 0.0f)
        {
            if (random)
            {
                spawnTime = Random.Range(0.0f, spawnDelay);
            }
            else
            {
                spawnTime = spawnDelay;
            }
            GameObject temp = Instantiate(enemyPrefab, transform.position, transform.rotation);
            temp.GetComponent<Move>().dir = dir;
        }
    }
}
