using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.Rendering;

public class BossBehavior : MonoBehaviour
{
    public int patternIndex;
    public int curPatternCount;
    public int[] maxPatternCount;
    public GameObject bossbullet;
    void Start()
    {
        Debug.Log("보스 등장");
        Invoke("Think", 3);
    }
    void Think()
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
    void BossPattern1()
    {
        Debug.Log("보스패턴 1 사용");



        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("BossPattern1", 1.0f);
        else
            Invoke("Think", 2);
    }
    void BossPattern2()
    {
        Debug.Log("보스패턴 2 사용");
        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("BossPattern2", 1.0f);
        else
        Invoke("Think", 3);
    }
    void BossPattern3()
    {
        Debug.Log("보스패턴 3 사용");
        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("BossPattern3", 1.0f);
        else
            Invoke("Think", 4);
    }
    void BossPattern4()
    {
        Debug.Log("보스패턴 4 사용");
        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("BossPattern4", 1.0f);
        else
            Invoke("Think", 1);
    }
}
