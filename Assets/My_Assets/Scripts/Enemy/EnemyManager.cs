using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.IO;
public class EnemyManager : MonoBehaviour
{
    [SerializeField] private int enemySListLength = 20;
    [SerializeField] private int enemyMListLength = 10;
    [SerializeField] private int enemyLListLength = 5;
    [SerializeField] private GameObject enemyS; //_enemyS
    [SerializeField] private GameObject enemyM; //_enemyM
    [SerializeField] private GameObject enemyL; //_enemyL
    List<GameObject> enemySList = new List<GameObject>();
    List<GameObject> enemyMList = new List<GameObject>();
    List<GameObject> enemyLList = new List<GameObject>();

    List<EnemySpawn> enemySpawnList = new List<EnemySpawn>();

    [SerializeField] private GameObject[] spawnPoints;

    private int spawnCount = 0;
    private bool spawnEnd = false;
    private float currentTime;
    private float nextSpawnDelay;

    private void Start()
    { 
        PullingEnemyS();
        PullingEnemyM();
        PullingEnemyL();

    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        ReadSpawnFile();
        SpawnEnemy();
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

    private void PullingEnemyM()
    {
        for (int i = 0; i < enemyMListLength; i++)
        {
            GameObject _enemyM = Instantiate(enemyM);
            enemyMList.Add(_enemyM);

            _enemyM.SetActive(false);

            _enemyM.transform.parent = transform;
        }
    }

    private void PullingEnemyL()
    {
        for (int i = 0; i < enemyLListLength; i++)
        {
            GameObject _enemyL = Instantiate(enemyL);
            enemyLList.Add(_enemyL);

            _enemyL.SetActive(false);

            _enemyL.transform.parent = transform;
        }
    }

    private GameObject GetInactiveEnemy(List<GameObject> enemyList)
    {
        foreach (GameObject enemy in enemyList)
        {
            if (!enemy.activeSelf)
            {
                return enemy;
            }
        }
        return null;
    }

    private void ReadSpawnFile()
    {
        TextAsset stage1 = Resources.Load("Stage 1") as TextAsset;
        StringReader stringReader = new StringReader(stage1.text);

        while (stringReader != null)
        {
            string line = stringReader.ReadLine();

            if (line == null)
                break;
        
            EnemySpawn enemySpawnData = new EnemySpawn();

            enemySpawnData.spawnTime = float.Parse(line.Split(',')[0]); //스폰 시간 float
            enemySpawnData.enemyType = line.Split(',')[1];              //적 유형 string
            enemySpawnData.spawnPoint = int.Parse(line.Split(',')[2]);  //스폰포인트 int

            enemySpawnList.Add(enemySpawnData);

            if (currentTime > enemySpawnData.spawnTime)
            {
                if (spawnCount >= enemySpawnList.Count)
                {
                    spawnEnd = true;
                    return;
                }

                EnemySpawn spawnData = enemySpawnList[spawnCount];

                GameObject enemyToSpawn = null;

                switch (spawnData.enemyType)
                {
                    case "S":
                        enemyToSpawn = GetInactiveEnemy(enemySList);
                        break;
                    case "M":
                        enemyToSpawn = GetInactiveEnemy(enemyMList);
                        break;
                    case "L":
                        enemyToSpawn = GetInactiveEnemy(enemyLList);
                        break;
                }

                if (enemyToSpawn != null)
                {
                    GameObject spawnPoint = spawnPoints[spawnData.spawnPoint - 1];
                    enemyToSpawn.transform.position = spawnPoint.transform.position;
                    enemyToSpawn.SetActive(true);
                }

                spawnCount++;

                if (spawnCount < enemySpawnList.Count)
                {
                    nextSpawnDelay = enemySpawnList[spawnCount].spawnTime;
                }
                else
                {
                    spawnEnd = true;
                }
            }
        }
        stringReader.Close();

    }

    private void SpawnEnemy()
    {
        
    }

    
}


