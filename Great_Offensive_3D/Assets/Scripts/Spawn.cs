using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    [SerializeField]
    private GameObject soldier,boss;

    [SerializeField]
    private int spawnCount = 10;

    [SerializeField]
    private float spawnTime;

    [SerializeField]
    private float spawnDelay;

    [SerializeField]
    public Transform[] spawnPoints;

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnObjects()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnDelay);

        // Initial wait
        yield return new WaitForSeconds(spawnTime);


        for (int count = spawnCount; count > 0; count-=2)
        {
            GameObject clone = Instantiate(soldier, spawnPoints[0].position, Quaternion.Euler(-90,0,-90));
            GameObject clone2 = Instantiate(soldier, spawnPoints[1].position, Quaternion.Euler(-90, 0, -90));
            // Detect when an ennemy gets destroyed

           

            yield return wait;
        }

        GameObject bossNew = Instantiate(boss, spawnPoints[0].position, Quaternion.Euler(-90, 0, -90));
        Debug.Log("All the ennemies have been instantiated !");
    }
}
