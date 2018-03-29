using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnCntrl : MonoBehaviour {

    public GameObject EnemyType1;   
    public bool spawnEnemies;   
    public int maxNumOfEnemies;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;



    private int EnemiesCounter;
    private float timerMax = 1f;
    private float timerMin = 0f;
    private Transform[] spawnPointList; 

   
    

	// Use this for initialization
	void Start () {
        spawnEnemies = true;
        EnemiesCounter = 0; 
        maxNumOfEnemies = 30; 
	}
	
	// Update is called once per frame
	void Update () {

        if(spawnEnemies && EnemiesCounter < maxNumOfEnemies)
        {
            timerMax -= Time.deltaTime;
            if (timerMax < timerMin)
            {             
                EnemiesCounter++; 
                Instantiate(EnemyType1, spawnPoint1); 
                timerMax = 2f; // reset timer
            }
        }
        if (spawnEnemies && EnemiesCounter < maxNumOfEnemies)
        {
            timerMax -= Time.deltaTime;
            if (timerMax < timerMin)
            {
                EnemiesCounter++;
                Instantiate(EnemyType1, spawnPoint2);
                timerMax = 2f; // reset timer
            }
        }
        if (spawnEnemies && EnemiesCounter < maxNumOfEnemies)
        {
            timerMax -= Time.deltaTime;
            if (timerMax < timerMin)
            {
                EnemiesCounter++;
                Instantiate(EnemyType1, spawnPoint3);
                timerMax = 4f; // reset timer
            }
        }
        if (spawnEnemies && EnemiesCounter < maxNumOfEnemies)
        {
            timerMax -= Time.deltaTime;
            if (timerMax < timerMin)
            {
                EnemiesCounter++;
                Instantiate(EnemyType1, spawnPoint4);
                timerMax = 3f; // reset timer
            }
        }

    }

  

}
