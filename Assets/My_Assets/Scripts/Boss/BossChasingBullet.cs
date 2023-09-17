using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChasingBullet : MonoBehaviour
{
    public float moveSpeed = 5.0f; // 이동 속도
    private Transform player; // 플레이어 오브젝트의 Transform 컴포넌트
    public GameObject particle;
    private TrailRenderer trailRenderer;

    void Start()
    {
        // 플레이어 오브젝트를 찾아서 저장
        trailRenderer = GetComponent<TrailRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // 플레이어가 없으면 스크립트 비활성화
        if (player == null)
        {
            Debug.LogError("플레이어를 찾을 수 없습니다. 스크립트를 비활성화합니다.");
            enabled = false;
        }


        //5초후 disable됨
        Invoke("DisableObject", 5.0f);
    }

    void Update()
    {
        // 플레이어가 존재하는지 확인
        if (player != null)
        {
            // 플레이어 방향 계산
            Vector3 direction = (player.position - transform.position).normalized;

            // 이동 벡터 계산
            Vector3 moveVector = direction * moveSpeed * Time.deltaTime;

            // 이동
            transform.Translate(moveVector);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        player.GetComponent<PlayerInfo>()._PlayerHp--;
        //Debug.Log("보스콜리전 맞음");
        //if (collision.gameObject.layer == 6)
        //{
        //    Debug.Log("보스이프 맞음");
        //    Destroy(gameObject);
        //}
    }
    void DisableObject()
    {
        // 오브젝트를 비활성화
        gameObject.SetActive(false);
    }
    void OnDisable()
    {
        // 오브젝트가 비활성화될 때 파티클 재생
        PlayParticleEffect();
        //오브젝트 비활성화시 삭제
        Destroy(gameObject);
    }

    void PlayParticleEffect()
    {
        // 파티클 프리팹을 인스턴스화하고 위치를 현재 오브젝트의 위치로 설정
        if (particle != null)
        {
            Instantiate(particle, transform.position, Quaternion.identity);
        }
    }
}
