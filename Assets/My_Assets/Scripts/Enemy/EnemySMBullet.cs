using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySMBullet : MonoBehaviour
{
    [SerializeField] private float enemySMBulletSpeed = 14;
    [SerializeField] private float enemySMBulletDestroy = 5;

    private GameObject player;
    private GameObject gameManager;

    Vector3 enemySMBulletDir;
    void Start()
    {
        player = GameObject.Find("Player");
        //gameManager = GameObject.Find("gameManager");

        enemySMBulletDir = (player.transform.position - transform.position).normalized;

        Destroy(gameObject, enemySMBulletDestroy);
    }

    void Update()
    {
        //transform.Translate(enemySMBulletDir * enemySMBulletSpeed * Time.deltaTime);
        transform.position += enemySMBulletDir * enemySMBulletSpeed * Time.deltaTime;

    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Debug.Log("콜리전 맞음");
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("이프 맞음");
            gameObject.SetActive(false);
        }
    }
}
