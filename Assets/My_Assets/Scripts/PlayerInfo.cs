using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int MaxPlayerHp; //�ִ�ü��
    public int PlayerHp;  //����ü��
    public int PlayerATK; //�÷��̾� ���� ���ݷ�
    //�߰�: ���ʹ� �ҷ� ������
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Debug.Log("���ظ� ����");

        }
    }
}
