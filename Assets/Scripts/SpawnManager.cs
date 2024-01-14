using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerController playerScript;

    public GameObject[] obstaclePrefabs; // Array untuk menyimpan obstacle-obstacle yang berbeda
    //public GameObject obstacle;

    private float laneMid = 0.3f;    // Posisi x untuk lane tengah
    private float laneLeft = -2.6f;  // Posisi x untuk lane kiri
    private float laneRight = 3.22f;  // Posisi x untuk lane kanan

    //private float spawnLimitXLeft = -3.0f;
    //private float spawnLimitXRight = 3.0f;

    private float initialSpawnDelay = 2.0f;
    private float spawnDelay = 2.0f; // Delay awal dan delay saat ini
    private float spawnDelayDecreaseRate = 0.0f; // Tingkat pengurangan delay per detik
    private float minSpawnDelay = 0.5f; // Delay minimum yang diinginkan

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", initialSpawnDelay, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        // Meningkatkan tingkat spawn setiap detik
        spawnDelay -= spawnDelayDecreaseRate * Time.deltaTime;
        // Pastikan spawnDelay tidak kurang dari minSpawnDelay
        spawnDelay = Mathf.Max(spawnDelay, minSpawnDelay);
    }

    public void SpawnObstacle()
    {
        if (!playerScript.gameOver)
        {
            // Pilih secara acak antara lane tengah, kiri, atau kanan
            float randomLane = Random.Range(0.0f, 3.0f);

            // Tentukan posisi spawn berdasarkan lane yang dipilih
            float spawnX;
            if (randomLane < 1.0f)
            {
                spawnX = laneLeft;   // Lane kiri dipilih
            }
            else if (randomLane < 2.0f)
            {
                spawnX = laneMid;    // Lane tengah dipilih
            }
            else
            {
                spawnX = laneRight;  // Lane kanan dipilih
            }

            //float randomX = Random.Range(spawnLimitXLeft, spawnLimitXRight);
            Vector3 spawnPos = new Vector3(spawnX, 2.0f, 40.0f);

            // Pilih secara acak obstacle dari array obstaclePrefabs
            int randomObstacleIndex = Random.Range(0, obstaclePrefabs.Length);

            // Instantiate obstacle yang dipilih
            Instantiate(obstaclePrefabs[randomObstacleIndex], spawnPos, obstaclePrefabs[randomObstacleIndex].transform.rotation);

            //Instantiate(obstacle, new Vector3(-0.04f, 0.75f, 25.0f), obstacle.transform.rotation);
            //Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
        }
    }

}

