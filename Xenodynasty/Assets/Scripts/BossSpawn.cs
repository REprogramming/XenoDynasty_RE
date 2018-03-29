using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{

    public GameObject BossMans;        
    public bool spawnEnemies;
    public int maxNumOfEnemies;
    public Transform spawnPoint1;
  



    private int EnemiesCounter;
    private float timerMax = 1f;
    private float timerMin = 0f;
    private Transform[] spawnPointList;




    // Use this for initialization
    void Start()
    {
        spawnEnemies = true;
        EnemiesCounter = 0;
        maxNumOfEnemies = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (spawnEnemies && EnemiesCounter < maxNumOfEnemies)
        {
            timerMax -= Time.deltaTime;
            if (timerMax < timerMin)
            {
                EnemiesCounter++;
                Instantiate(BossMans, spawnPoint1);
                timerMax = .5f; // reset timer
            }
        }

    }



}
