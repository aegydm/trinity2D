using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int MaxPlayerHp; //�ִ�ü��
    private int PlayerHp;  //����ü��
    public int PlayerATK; //�÷��̾� ���� ���ݷ�
    //�߰�: ���ʹ� �ҷ� ������ // ���ʹ� �Ѿ˵��� ���� PlayerHp-- �� ����Կ�

    public int _PlayerHP
    {
        get
        {
            return PlayerHp;
        }
        set
        {
            PlayerHp = value;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Debug.Log("���ظ� ����");

        }
    }
}
