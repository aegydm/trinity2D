using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.IO;
public class EnemyManager : MonoBehaviour
{
    public int enemySListLength = 20;
    public int enemyMListLength = 10;
    public int enemyLListLength = 5;
    public GameObject enemyS; //_enemyS
    public GameObject enemyM; //_enemyM
    public GameObject enemyL; //_enemyL
    List<GameObject> enemySList = new List<GameObject>();
    List<GameObject> enemyMList = new List<GameObject>();
    List<GameObject> enemyLList = new List<GameObject>();

    List<EnemySpawn> enemySpawnList = new List<EnemySpawn>();

    public int spawnCount = 0;
    public bool spawnEnd = false;

    float currentTime;
    private void Start()
    { 
        PullingEnemyS();
        PullingEnemyM();
        PullingEnemyL();
        ESActivation();
        EMActivation();
        ELActivation();

        ReadSpawnFile();
    }

    public void Update()
    {
        currentTime += Time.deltaTime;
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

    public void ESActivation()
    {
        foreach (GameObject _enemyS in enemySList)
        {
            if (!_enemyS.activeSelf)
            {
                _enemyS.SetActive(true);
            }
        }
    }

    public void EMActivation()
    {

        foreach (GameObject _enemyM in enemyMList)
        {
            if (!_enemyM.activeSelf)
            {
                _enemyM.SetActive(true);
            }
        }
    }

    public void ELActivation()
    {
        foreach (GameObject _enemyL in enemyLList)
        {
            if (!_enemyL.activeSelf)
            {
                _enemyL.SetActive(true);
            }
        }
    }

    public void ReadSpawnFile()
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
        }
        stringReader.Close();

        //nextSpawnDelay = enemySpawnList[0].spawnTime;

    }

    public void SpawnEnemy()
    {
        EnemySpawn spawnData = enemySpawnList[spawnCount];
        
        int enemyTypeIndex = 0;

        switch (enemySpawnList[spawnCount].enemyType) //줄이 바뀔 때 마다 스위치 실행 
        {
            case "S":
                enemyTypeIndex = 0;
                break;
            case "M":
                enemyTypeIndex = 1;
                break;
            case "L":
                enemyTypeIndex = 2;
                break;
        }





        if (spawnCount >= enemySpawnList.Count) // 줄이 바뀌었는데 리스트 줄 수 보다 크거나 같으면 스폰 종료
        {
            spawnEnd = true;
            return;
        }
    }
}
