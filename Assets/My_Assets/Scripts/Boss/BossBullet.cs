using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 dir = Vector3.left;

    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;

        if (transform.position.x < -10 || transform.position.x > 10 || transform.position.y > 5.5f || transform.position.y < -5.5f)
        {
            Destroy(gameObject);
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
}
