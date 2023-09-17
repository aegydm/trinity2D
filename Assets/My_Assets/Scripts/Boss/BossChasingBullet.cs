using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChasingBullet : MonoBehaviour
{
    public float moveSpeed = 5.0f; // �̵� �ӵ�
    private Transform player; // �÷��̾� ������Ʈ�� Transform ������Ʈ
    public GameObject particle;
    private TrailRenderer trailRenderer;

    void Start()
    {
        // �÷��̾� ������Ʈ�� ã�Ƽ� ����
        trailRenderer = GetComponent<TrailRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // �÷��̾ ������ ��ũ��Ʈ ��Ȱ��ȭ
        if (player == null)
        {
            Debug.LogError("�÷��̾ ã�� �� �����ϴ�. ��ũ��Ʈ�� ��Ȱ��ȭ�մϴ�.");
            enabled = false;
        }


        //5���� disable��
        Invoke("DisableObject", 5.0f);
    }

    void Update()
    {
        // �÷��̾ �����ϴ��� Ȯ��
        if (player != null)
        {
            // �÷��̾� ���� ���
            Vector3 direction = (player.position - transform.position).normalized;

            // �̵� ���� ���
            Vector3 moveVector = direction * moveSpeed * Time.deltaTime;

            // �̵�
            transform.Translate(moveVector);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        player.GetComponent<PlayerInfo>()._PlayerHp--;
        //Debug.Log("�����ݸ��� ����");
        //if (collision.gameObject.layer == 6)
        //{
        //    Debug.Log("�������� ����");
        //    Destroy(gameObject);
        //}
    }
    void DisableObject()
    {
        // ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
    void OnDisable()
    {
        // ������Ʈ�� ��Ȱ��ȭ�� �� ��ƼŬ ���
        PlayParticleEffect();
        //������Ʈ ��Ȱ��ȭ�� ����
        Destroy(gameObject);
    }

    void PlayParticleEffect()
    {
        // ��ƼŬ �������� �ν��Ͻ�ȭ�ϰ� ��ġ�� ���� ������Ʈ�� ��ġ�� ����
        if (particle != null)
        {
            Instantiate(particle, transform.position, Quaternion.identity);
        }
    }
}
