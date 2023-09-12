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
    //    List<GameObject> enemyLList = new List<GameObject>(); // Ǯ���� ����Ʈ
    //    [SerializeField] private GameObject[] spawnPoints;    // ���� ����Ʈ �迭

    //    List<EnemySpawn> enemySpawnList = new List<EnemySpawn>();  // �ؽ�Ʈ���� �о�� ���� ����� ����Ʈ

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

        Debug.Log("Ǯ�� �Ϸ�");
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
    //                Debug.Log("Ǯ�� Ȱ��ȭ");
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

    //            es.spawnTime = float.Parse(line.Split(',')[0]); //���� �ð� float
    //            es.enemyType = line.Split(',')[1];              //�� ���� string
    //            es.spawnPoint = int.Parse(line.Split(',')[2]);  //��������Ʈ int

    //            Debug.Log("�ð�" + es.spawnTime);
    //            Debug.Log("����" + es.enemyType);
    //            Debug.Log("��ġ" + es.spawnPoint);

    //            enemySpawnList.Add(enemySpawnData);
    //            Debug.Log(enemySpawnData);
    //        }
    //        stringReader.Close();
    //    }

    //    public void SpawnEnemy()
    //    {
    //        while (spawnEnd)
    //        {
    //            Debug.Log(spawnEnd); //11�� ����
    //            switch (enemySpawnData.enemyType)
    //            {
    //                case "S":
    //                    enemyToSpawn = GetInactiveEnemy(enemySList); //10�� Ȱ��ȭ txt������ 8��
    //                    Debug.Log("S ��ȯ");
    //                    break;
    //                case "M":
    //                    enemyToSpawn = GetInactiveEnemy(enemyMList);
    //                    Debug.Log("M ��ȯ");
    //                    break;
    //                case "L":
    //                    enemyToSpawn = GetInactiveEnemy(enemyLList);
    //                    Debug.Log("L ��ȯ");
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



