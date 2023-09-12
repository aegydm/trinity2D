using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private int enemySListLength = 20;
    [SerializeField] private GameObject enemyS;
    List<GameObject> enemySList = new List<GameObject>();
    [SerializeField] private GameObject enemyToSpawn;
    [SerializeField] private GameObject[] spawnpoints;
    private int ranIndex;

    //private void Start()
    //{
    //    PullingEnemyS();

    //    Stage1();
    //}



    private void Update()
    {
        ranIndex = UnityEngine.Random.Range(0, spawnpoints.Length);
    }

    private void PullingEnemyS()
    {
        for (int i = 0; i < enemySListLength; i++)
        {
            GameObject _enemyS = Instantiate(enemyS);
            enemySList.Add(_enemyS);

            _enemyS.SetActive(false);

            _enemyS.transform.parent = transform;
        }
    }

    private GameObject GetInActivateEnemy(List<GameObject> enemySList)
    {
        foreach (GameObject enemy in enemySList)
        {
            if (!enemy.activeSelf)
            {
                return enemy;
            }
        }
        return null;
    }

    private void EnemySSpawn()
    {
        enemyToSpawn = GetInActivateEnemy(enemySList);

        if (enemyToSpawn != null)
        {
            GameObject spawnpoint = spawnpoints[ranIndex];
            enemyToSpawn.transform.position = spawnpoint.transform.position;
            enemyToSpawn.SetActive(true);
        }
    }

    private void Stage1()
    {
        Invoke("EnemySSpawn", 0);
        Invoke("EnemySSpawn", 2);
        Invoke("EnemySSpawn", 4);
        Invoke("EnemySSpawn", 4.1f);
    }
}

