using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    [SerializeField] private int patternIndex;
    [SerializeField] private int curPatternCount;
    [SerializeField] private int[] maxPatternCount;
    [SerializeField] private GameObject bossbullet;
    [SerializeField] private GameObject gunPos;
    [SerializeField] private int degree = 15;
    [SerializeField] private Animator animator;
    
    [SerializeField] private Slider BossRushIndicator;
    private float maxIndicator = 100;
    private float curIndicator = 0;  
    
    void Start()
    {
        BossRushIndicator.value = (float)curIndicator / (float)maxIndicator;

        Debug.Log("���� ����");
        Invoke("Think", 3);
    }
   private void Update(){
        if (Input.GetKeyDown(KeyCode.Space))
            Debug.Log("��������");
        {
            curIndicator += 100;
        }
        HandleIndicator();
    }

    private void Think()
    {
        Debug.Log("���� ������");
        patternIndex = patternIndex == 3 ? 0 : patternIndex + 1;
        curPatternCount = 0;// �ʱ�ȭ
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
        Debug.Log("�������� 1 ���");
        int numOfBullet = 195 / degree;
        for (int i = 0; i < numOfBullet; i++)
        {
            GameObject bulletGO = Instantiate(bossbullet);
            bulletGO.transform.position = gunPos.transform.position;
            bulletGO.transform.rotation = Quaternion.Euler(0, 0, (i + 270) * degree);
            bulletGO.GetComponent<BossBullet>().dir = bulletGO.transform.right;
        }
        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("BossPattern1", 0.1f);
        else
            Invoke("Think", 2);
    }
    private  void BossPattern2()
    {
        Debug.Log("�������� 2 ���");
        animator.SetTrigger("BossTackle");
        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("BossPattern2", 1.0f);
        else
        Invoke("Think", 3);
    }
    private void BossPattern3()
    {
        Debug.Log("�������� 3 ���");
        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("BossPattern3", 1.0f);
        else
            Invoke("Think", 4);
    }
    private void BossPattern4()
    {
        Debug.Log("�������� 4 ���");
        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("BossPattern4", 1.0f);
        else
            Invoke("Think", 1);
    }

    private void HandleIndicator()
    {
        BossRushIndicator.value = Mathf.Lerp(BossRushIndicator.value, (float)curIndicator/(float)maxIndicator, Time.deltaTime * 0.01f);
    }

}
