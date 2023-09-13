using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int MaxPlayerHp = 3; //�ִ�ü��
    [SerializeField] private int PlayerHp;  //����ü��
    public int PlayerATK; //�÷��̾� ���� ���ݷ�
    //�߰�: ���ʹ� �ҷ� ������

    private void Start()
    {
        PlayerHp = MaxPlayerHp;
    }
    public int _PlayerHp
    {
        get { return PlayerHp; }
        set { PlayerHp = value; }
    }

    private void OnCollisionEnter(Collision otherObject)
    {
        if (otherObject.gameObject.tag == "EnemySMBullet")
        {
            otherObject.gameObject.SetActive(false);

            if (PlayerHp <= 0)
            {
                GameManager.instance.GameOver();
            }
        }
    }
}
