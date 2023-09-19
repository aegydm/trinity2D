using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;
    //[SerializeField] private GameObject deathEffect;
    // [SerializeField] private bool isInvulnerable = false;
    [SerializeField] private Animator animator;

    private float invincibleTimer = 0;

    private GameObject player;

    public int _health {  get { return health; }
                          set {  health = value; } }

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void Update()
    {
       // invincibleTimer += Time.deltaTime;
    }
    /*  private void OnCollisionEnter(Collision collision)
      {
          player.GetComponent<PlayerInfo>()._PlayerHp--;

          if (collision.gameObject.tag == "PlayerBullet")
          {
              collision.gameObject.SetActive(false);
              if (invincibleTimer < 1)
              {
                  TakeDamage(-10);

                  Debug.Log("보스 히트");
                  //gameObject.transform.position = Vector3.zero;
                  //gameObject.transform.rotation = Quaternion.identity;

                  invincibleTimer = 0;
              }
          }
      }*/
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {

            TakeDamage(-10);
        }
    }


    public void TakeDamage(int damage)
    {
        /* if (isInvulnerable)
             return;*/
        health += damage;
        if (health <= 50) //체력이 절반 이하일떄
        {
            GetComponent<Animator>().SetBool("BossEnrage", true);
        }
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("보스 격파");
        animator.SetTrigger("BossDead");
        Invoke("BossGameOver", 3);

        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        //gameObject.SetActive(false);
        //Destroy(gameObject);
    }
    void BossGameOver()
    {
        GameManager.instance.GameOver();
    }
}
