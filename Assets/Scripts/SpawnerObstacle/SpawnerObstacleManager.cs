using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObstacleManager : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject jumperObstacle;
    public GameObject bonus;
    public int ratio = 0;
    public int ratioBonus = 0;
    public static SpawnerObstacleManager Instance;
    public float minTime;
    public float maxTime;
    public float timeBeforeSpawn;
    public float count = 0;
   
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        minTime = 1f;
        maxTime = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        
        count += Time.deltaTime;

        // Défini la durée avant le prochain spawn d'obstacle 
        if (timeBeforeSpawn == 0)
        {
            timeBeforeSpawn = Random.Range(minTime, maxTime);
        }
        if (timeBeforeSpawn <= count)
        {
            // Condition permettant de contrôler le spawn de bonus et d'obstacle sautant
            if (ratio >= 4 && GameplayManager.Instance.score >= 5000)
            {
                if (ratioBonus == 4)
                {
                    Instantiate(bonus, transform.position, Quaternion.identity);

                    ratioBonus = 0;
                }
                else
                {
                    Instantiate(jumperObstacle, transform.position, Quaternion.identity);
                }
                
                ratio = 0;
                ratioBonus++;
            }
            else
            {
                Instantiate(obstacle, transform.position, Quaternion.identity);
                    ratio++;
            }
            count = 0;
            timeBeforeSpawn = 0;
           
        }
        


    }

    public void SpawnObstacle()
    {
        
    }
}
