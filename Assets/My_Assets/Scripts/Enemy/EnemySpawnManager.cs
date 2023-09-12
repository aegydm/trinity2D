using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private float currentTime;
    [SerializeField] private float[] SpawnTime = { 0, 2, 4, 4 };

    [SerializeField] private GameObject EnemyS;
    [SerializeField] private Transform[] SpawnPoints;
    private int ranSPPoints;
    private int randomNumber;



    private void Start()
    {

    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        for(int i = 0; SpawnTime[i] < currentTime; ++i)
        {
            GameObject _enemyS = Instantiate(EnemyS);
            _enemyS.transform.position = SpawnPoints[randomNumber].position;
        }
    }

    void RandomPoints()
    {
        randomNumber = Random.Range(0, 3);
    }
}
