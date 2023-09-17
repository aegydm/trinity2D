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
    [SerializeField] private GameObject bossChasingbullet;
    [SerializeField] private GameObject gunPos;
    [SerializeField] private GameObject gunPosChasingUp;
    [SerializeField] private GameObject gunPosChasingDown;
    [SerializeField] private int degree = 15;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject indicator;

    void Start()
    {
        //indicator.SetActive(false);
        Debug.Log("���� ����");
        Invoke("Think", 3);
    }

    private void Think()
    {
        Debug.Log("���� ������");
        patternIndex = patternIndex == 2 ? 0 : patternIndex + 1;
        curPatternCount = 0;// �ʱ�ȭ
        switch (patternIndex)
        {

            case 0:
                BossPattern3();
                break;
            case 1:
                BossPattern1();
                break;
            case 2:
                BossPattern2();
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
    private void BossPattern2()
    {
        Debug.Log("�������� 2 ���");
        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
        {
            StartCoroutine(PatternTwoIndicatorOnOff());
            animator.SetTrigger("BossTackle");
            Invoke("BossPattern2", 1.0f);
        }
        else
            Invoke("Think", 3);
    }
    private void BossPattern3()
    {
        Debug.Log("�������� 3 ���");
        GameObject bulletGOup = Instantiate(bossChasingbullet);
        bulletGOup.transform.position = gunPosChasingUp.transform.position;
        GameObject bulletGOdown = Instantiate(bossChasingbullet);
        bulletGOdown.transform.position = gunPosChasingDown.transform.position;
        //bulletGOdown.GetComponent<BossBullet>().dir = bulletGOdown.transform.right;

        curPatternCount++;
        if (curPatternCount < maxPatternCount[patternIndex])
            Invoke("BossPattern3", 1.0f);
        else
            Invoke("Think", 4);
    }

    private IEnumerator PatternTwoIndicatorOnOff()
    {
        // ������Ʈ�� �մϴ�.
        indicator.SetActive(true);

        // 2�� ���
        yield return new WaitForSeconds(1.5f);

        // 2�� �Ŀ� ������Ʈ�� �ٽ� ���ϴ�.
        indicator.SetActive(false);
    }

}

