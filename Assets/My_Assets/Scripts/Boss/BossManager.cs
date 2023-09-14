using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.Rendering;

public class BossManager : MonoBehaviour
{
    [SerializeField] private int patternIndex;
    [SerializeField] private int curPatternCount;
    [SerializeField] private int[] maxPatternCount;
    [SerializeField] private GameObject bossbullet;
    [SerializeField] private GameObject gunPos;
    [SerializeField] private int degree = 15;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject Indicator;
    void Start()
    {
        Indicator = GameObject.Find("BossAttackIndicator");
        Indicator.GetComponent<BossAttackIndicator>();
        Debug.Log("보스 등장");
        Invoke("Think", 3);
    }
    private void Think()
    {
        Debug.Log("보스 생각해");
        patternIndex = patternIndex == 3 ? 0 : patternIndex + 1;
        curPatternCount = 0;// 초기화
        switch (patternIndex)
        {

            case 0:
                BossPattern4();
                break;
            case 1:
                BossPattern1();
                break;
            case 2:
                BossPattern2();
                break;
            case 3:
                BossPattern3();
                break;
        }
    }
    private void BossPattern1()
    {
        Debug.Log("보스패턴 1 사용");
        int numOfBullet = 360 / degree;
        for (int i = 0; i < numOfBullet; i++)
        {
            GameObject bulletGO = Instantiate(bossbullet);
            bulletGO.transform.position = gunPos.transform.position;
            bulletGO.transform.rotation = Quaternion.Euler(0, 0, i * degree);
            bulletGO.GetComponent<BossBullet>().dir = bulletGO.transform.right;
        }
        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("BossPattern1", 1.0f);
        else
            Invoke("Think", 2);
    }
    private  void BossPattern2()
    {

        Debug.Log("보스패턴 2 사용");
        StartCoroutine("Delay");
        animator.SetTrigger("BossTackle");
        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("BossPattern2", 1.0f);
        else
        Invoke("Think", 3);
    }
    private void BossPattern3()
    {
        
        Debug.Log("보스패턴 3 사용");
        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("BossPattern3", 1.0f);
        else
            Invoke("Think", 4);
    }
    private void BossPattern4()
    {
        Debug.Log("보스패턴 4 사용");
        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("BossPattern4", 1.0f);
        else
            Invoke("Think", 1);
    }
}
