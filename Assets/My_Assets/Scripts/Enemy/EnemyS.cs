using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//[SerializeField]
public class EnemyS : MonoBehaviour
{
    private enum ESState
    {
        Rush,
        CrossBLine,
        StopNTarget,
        TurningBack
    }

    ESState esstate;

    [SerializeField] private float enemySSpeed = 14.0f;
    [SerializeField] private float enemySdeselSpeed = 14.0f;
    [SerializeField] private float enemyFallBackRotate = 210.0f;
    private int enemySHP = 0;

    private Vector3 eSDir;
    private Vector3 eSLookDir;

    private Transform player;
    private int eSBL;

    private float currentTime;


    private void Awake()
    {
        RandomBL();

        transform.Rotate(0, -90f, 0);
    }
    private void Start()
    {
        player = GameObject.Find("Player").transform;

        esstate = ESState.Rush;
    }

    private void Update()
    {
        //if (GameManager.Instantiate.state != GameManager.GameState.inGame)
        //return;
        switch (esstate)
        {
            case ESState.Rush:
                Rush();
                break;
            case ESState.CrossBLine:
                CrossBLine();
                break;
            case ESState.StopNTarget:
                StopNTarget();
                break;
            case ESState.TurningBack:
                TurningBack();
                break;
        }
    }
    private void Rush()
    {
        LookPlayer();

        eSDir = Vector3.left;
        transform.Translate(eSDir * enemySSpeed * Time.deltaTime, Space.World);

        if (eSBL > transform.position.x)
        {
            Debug.Log("·¯½Ã > ºê·¹ÀÌÅ©");
            esstate = ESState.CrossBLine;
        }
    }
    private void CrossBLine()
    {
        LookPlayer();

        transform.Translate(eSDir * enemySSpeed * Time.deltaTime, Space.World);
        enemySSpeed -= enemySdeselSpeed * Time.deltaTime;

        if (enemySSpeed < -0.5f)
        {
            Debug.Log("ºê·¹ÀÌÅ© > ¸ØÃã");
            esstate = ESState.StopNTarget;
        }

    }

    private void StopNTarget()
    {
        LookPlayer();

        currentTime += Time.deltaTime;

        if (currentTime > 3)
        {
            Debug.Log("¸ØÃã > ÈÄÅð");
            esstate = ESState.TurningBack;
        }
    }
    private void TurningBack()
    {
        transform.Translate(eSDir * enemySSpeed * Time.deltaTime, Space.World);
        enemySSpeed -= enemySdeselSpeed * Time.deltaTime;

        if (transform.rotation.x <= 0)
        {
            transform.Rotate(Vector3.right * -enemyFallBackRotate * Time.deltaTime, Space.Self);
        }
        if (transform.rotation.x > 0)
        {
            transform.Rotate(Vector3.right * enemyFallBackRotate * Time.deltaTime, Space.Self);
        }

    }
    /// <summary>
    /// 
    /// </summary>
    /// 

    private void RandomBL()
    {
        int randomBreakL = UnityEngine.Random.Range(6, 11);

        eSBL = randomBreakL;
    }

    private void LookPlayer()
    {
        eSLookDir = transform.position - player.position;

        transform.rotation = Quaternion.LookRotation(eSLookDir);
    }
}
