using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int MaxPlayerHp = 3; //�ִ�ü��
    [SerializeField] private int PlayerHp;  //����ü��
    public int PlayerATK; //�÷��̾� ���� ���ݷ�
    //�߰�: ���ʹ� �ҷ� ������

    private float playerInvincibleTimer;

    private void Start()
    {
        PlayerHp = MaxPlayerHp;
    }
    public int _PlayerHp
    {
        get { return PlayerHp; }
        set {if (playerInvincibleTimer > 1){PlayerHp = value; playerInvincibleTimer = 0; } }
    }

    public void Update()
    {
        playerInvincibleTimer += Time.deltaTime;
    }
    private void OnCollisionEnter(Collision otherObject)
    {
        if (otherObject.gameObject.tag == "EnemySMBullet" || otherObject.gameObject.tag == "BossBullet")
        {
            otherObject.gameObject.SetActive(false);
            Debug.Log("E,B �Ѿ� �ı���");

            if (PlayerHp <= 0)
            {
                Destroy(gameObject);
                GameManager.instance.GameOver();
            }
        }
    }
}
