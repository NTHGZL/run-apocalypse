using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObstacleManager : MonoBehaviour
{
    public GameObject obstacle;
    public float minTime;
    public float timeBeforeSpawn;
    public float count = 0;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;

        if (timeBeforeSpawn == 0)
        {
            timeBeforeSpawn = Random.Range(0.7f, 2f);
        }
        if (timeBeforeSpawn <= count)
        {
            Instantiate(obstacle, transform.position, Quaternion.identity);
            count = 0;
            timeBeforeSpawn = 0;
        }
        


    }

    public void SpawnObstacle()
    {
        
    }
}
