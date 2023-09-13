using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int MaxPlayerHp; //최대체력
    private int PlayerHp;  //현재체력
    public int PlayerATK; //플레이어 기초 공격력
    //추가: 에너미 불렛 데미지 // 에너미 총알뎀지 전부 PlayerHp-- 로 만들게요

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
            Debug.Log("피해를 입음");

        }
    }
}
