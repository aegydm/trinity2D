using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject boss;
    public GameObject bossBullet;

    public int poolSize = 100;      // ����źâ
    public List<GameObject> BossBulletPool;

    // Start is called before the first frame update
    void Start()
    {
        BossBulletPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject BossBulletGo = Instantiate(bossBullet);

            BossBulletPool.Add(BossBulletGo);
            BossBulletGo.SetActive(false);
        }
    }
    // enemy������ ����ϴ� �Ŵ����� ���� �ϳ� �������� �ϴ� ����(�׽�Ʈ��)
    // enemy�� ������Ų��

    //������ pulling �Ǿ��ִٴ� �����Ͽ� active ��Ű�°����� �ڵ��� ��
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && boss.activeInHierarchy == false)
        {
            boss.SetActive(true);
        }
    }
}
