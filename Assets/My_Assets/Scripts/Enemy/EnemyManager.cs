using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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


    private void Start()
    {
        PullingEnemyS();
        PullingEnemyM();
        PullingEnemyL();
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
            GameObject _enemyM = Instantiate(enemyS);
            enemyMList.Add(_enemyM);

            _enemyM.SetActive(false);

            _enemyM.transform.parent = transform;
        }
    }

    private void PullingEnemyL()
    {
        for (int i = 0; i < enemyLListLength; i++)
        {
            GameObject _enemyL = Instantiate(enemyS);
            enemyLList.Add(_enemyL);

            _enemyL.SetActive(false);

            _enemyL.transform.parent = transform;
        }
    }
}
