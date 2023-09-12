using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.IO;
public class EnemyManager : MonoBehaviour
{
    [SerializeField] private int enemySListLength = 20;
//    [SerializeField] private int enemyMListLength = 10;
//    [SerializeField] private int enemyLListLength = 5;
    [SerializeField] private GameObject enemyS; //_enemyS
                                                //    [SerializeField] private GameObject enemyM; //_enemyM
                                                //    [SerializeField] private GameObject enemyL; //_enemyL
    List<GameObject> enemySList = new List<GameObject>();
    //    List<GameObject> enemyMList = new List<GameObject>();
    //    List<GameObject> enemyLList = new List<GameObject>(); // 풀링용 리스트
    //    [SerializeField] private GameObject[] spawnPoints;    // 스폰 포인트 배열

    //    List<EnemySpawn> enemySpawnList = new List<EnemySpawn>();  // 텍스트파일 읽어온 정보 저장용 리스트

    //    public GameObject enemyToSpawn;

    //    EnemySpawn enemySpawnData;

    //    private bool spawnEnd = true;

    private void Start()
    {
        PullingEnemyS();
        //        PullingEnemyM();
        //        PullingEnemyL();

        //        ReadSpawnFile();

        //        SpawnEnemy();
    }

    //    private void Update()
    //    {

    //    }

    private void PullingEnemyS()
{
    for (int i = 0; i < enemySListLength; i++)
    {
        GameObject _enemyS = Instantiate(enemyS);
        enemySList.Add(_enemyS);

        _enemyS.SetActive(false);

        _enemyS.transform.parent = transform;

        Debug.Log("풀링 완료");
    }
}

    //    private void PullingEnemyM()
    //    {
    //        for (int i = 0; i < enemyMListLength; i++)
    //        {
    //            GameObject _enemyM = Instantiate(enemyM);
    //            enemyMList.Add(_enemyM);

    //            _enemyM.SetActive(false);

    //            _enemyM.transform.parent = transform;
    //        }
    //    }

    //    private void PullingEnemyL()
    //    {
    //        for (int i = 0; i < enemyLListLength; i++)
    //        {
    //            GameObject _enemyL = Instantiate(enemyL);
    //            enemyLList.Add(_enemyL);

    //            _enemyL.SetActive(false);

    //            _enemyL.transform.parent = transform;
    //        }
    //    }

    //    private GameObject GetInactiveEnemy(List<GameObject> enemyList)
    //    {
    //        foreach (GameObject enemy in enemyList)
    //        {
    //            if (!enemy.activeSelf)
    //            {
    //                Debug.Log("풀링 활성화");
    //                return enemy;
    //            }
    //        }
    //        return null;
    //    }

    //    private void ReadSpawnFile()
    //    {
    //        TextAsset stage1 = Resources.Load("Stage 1") as TextAsset;
    //        StringReader stringReader = new StringReader(stage1.text);

    //        while (stringReader != null)
    //        {
    //            string line = stringReader.ReadLine();

    //            if (line == null)
    //                break;

    //            EnemySpawn es = new EnemySpawn();

    //            es.spawnTime = float.Parse(line.Split(',')[0]); //스폰 시간 float
    //            es.enemyType = line.Split(',')[1];              //적 유형 string
    //            es.spawnPoint = int.Parse(line.Split(',')[2]);  //스폰포인트 int

    //            Debug.Log("시간" + es.spawnTime);
    //            Debug.Log("유형" + es.enemyType);
    //            Debug.Log("위치" + es.spawnPoint);

    //            enemySpawnList.Add(enemySpawnData);
    //            Debug.Log(enemySpawnData);
    //        }
    //        stringReader.Close();
    //    }

    //    public void SpawnEnemy()
    //    {
    //        while (spawnEnd)
    //        {
    //            Debug.Log(spawnEnd); //11번 돈다
    //            switch (enemySpawnData.enemyType)
    //            {
    //                case "S":
    //                    enemyToSpawn = GetInactiveEnemy(enemySList); //10번 활성화 txt파일은 8줄
    //                    Debug.Log("S 소환");
    //                    break;
    //                case "M":
    //                    enemyToSpawn = GetInactiveEnemy(enemyMList);
    //                    Debug.Log("M 소환");
    //                    break;
    //                case "L":
    //                    enemyToSpawn = GetInactiveEnemy(enemyLList);
    //                    Debug.Log("L 소환");
    //                    break;
    //            }
    //            if (enemyToSpawn != null)
    //            {
    //                GameObject spawnPoint = spawnPoints[enemySpawnData.spawnPoint - 1];
    //                enemyToSpawn.transform.position = spawnPoint.transform.position;
    //                enemyToSpawn.SetActive(true);
    //            }
    //            else
    //            {
    //                spawnEnd = false;
    //                Debug.Log(spawnEnd);
    //            }
    //        }
    //    }
}



