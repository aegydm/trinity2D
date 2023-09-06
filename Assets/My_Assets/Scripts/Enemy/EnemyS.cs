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
        StopAtk,
        Back
    }

    ESState esstate;

    [SerializeField] private float enemySSpeed = 14.0f;
    [SerializeField] private float enemySdecelerationSpeed = 2.0f;
    [SerializeField] private int enemySHP = 1;

    private Vector3 ESDir;

    [SerializeField] Transform player; //����ź �߻縦 ���� �÷��̾� ��ġ
    [SerializeField] Transform[] eSBLList;//Enemy S Break Line 3���� �ϳ�

    Transform eSBL;

    private void Awake()
    {
        RandomBL();

        enemySSpeed = Mathf.Clamp(enemySSpeed, 0, enemySSpeed); ;
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
            case ESState.StopAtk:
                StopAtk();
                break;
            case ESState.Back:
                Back();
                break;
        }
    }
    private void Rush()
    {
        Vector3 ESDir = Vector3.left;
        transform.Translate(ESDir * enemySSpeed * Time.deltaTime);

        if(transform.position.x < eSBL.transform.position.x)
        {
            esstate = ESState.StopAtk;

            print("������");
        }
    }
    private void StopAtk()
    {
        print("���º��� StopAtk");
        Vector3 ESDir = Vector3.left;
        enemySSpeed -= enemySdecelerationSpeed * Time.deltaTime;

        if (enemySSpeed <= -0.2f)
        {
            enemySdecelerationSpeed = 0.03f;
            esstate = ESState.Back;
        }
    }

    private void Back()
    {
        Vector3 ESR = Vector3.back;
        transform.Rotate(ESR * 45 * Time.deltaTime);
        if (transform.rotation.x <= -90)
        {
            enemySdecelerationSpeed = 40f;
        }
    }

    private void RandomBL()
    {
        if (eSBLList.Length > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, eSBLList.Length);

            eSBL = eSBLList[randomIndex];

            print(randomIndex);
        }
    }
}
//enemySdecelerationSpeed = 40f;
//transform.Rotate(ESR * 45 * Time.deltaTime);
//���ʹ� �����̴°� �Լ��� ���� ��� ���¿� �ֱ�