using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int MaxPlayerHp = 3; //최대체력
    [SerializeField] private int PlayerHp;  //현재체력
    public int PlayerATK; //플레이어 기초 공격력
    //추가: 에너미 불렛 데미지

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
