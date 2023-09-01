using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    // enemy출현을 담당하는 매니저를 보스 하나 전용으로 일단 만듬(테스트용)
    // enemy를 출현시킨다
    public GameObject boss; //보스캐릭터

    //보스가 pulling 되어있다는 가정하에 active 시키는것으로 코딩을 함
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && boss.activeInHierarchy == false )
        {
            boss.SetActive(true);  
        }
    }
}
