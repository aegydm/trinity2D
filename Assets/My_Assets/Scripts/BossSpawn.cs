using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    // enemy������ ����ϴ� �Ŵ����� ���� �ϳ� �������� �ϴ� ����(�׽�Ʈ��)
    // enemy�� ������Ų��
    public GameObject boss; //����ĳ����

    //������ pulling �Ǿ��ִٴ� �����Ͽ� active ��Ű�°����� �ڵ��� ��
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && boss.activeInHierarchy == false )
        {
            boss.SetActive(true);  
        }
    }
}
