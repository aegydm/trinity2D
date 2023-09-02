using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyManager : MonoBehaviour
{
    public int enemyListLength = 20;
    public GameObject enemyS;
    public GameObject enemyM;
    public GameObject enemyL;
    List<GameObject> enemyList = new List<GameObject>();


    private void Start()
    {

    }

    private void PullingEnemyS()
    {
        for (int i = 0; i < enemyListLength; i++)
        {
            GameObject _enemyS = Instantiate(enemyS);
            enemyList.Add(_enemyS);

            _enemyS.SetActive(false);

            _enemyS.transform.parent = transform;
        }
    }

    private void PullingEnemyM()
    {
        for (int i = 0; i < enemyListLength; i++)
        {
            GameObject _enemyS = Instantiate(enemyS);
            enemyList.Add(_enemyS);

            _enemyS.SetActive(false);

            _enemyS.transform.parent = transform;
        }
    }

    private void PullingEnemyL()
    {
        for (int i = 0; i < enemyListLength; i++)
        {
            GameObject _enemyS = Instantiate(enemyS);
            enemyList.Add(_enemyS);

            _enemyS.SetActive(false);

            _enemyS.transform.parent = transform;
        }
    }
}
