using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField]private int health = 100;
    //[SerializeField] private GameObject deathEffect;
   // [SerializeField] private bool isInvulnerable = false;
    [SerializeField] private Animator animator;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            TakeDamage(-10);
                   
            Debug.Log("���� ��Ʈ");
            gameObject.transform.position = Vector3.zero;
            gameObject.transform.rotation = Quaternion.identity;
        }
    }


    public void TakeDamage(int damage)
    {
       /* if (isInvulnerable)
            return;*/
        health += damage;
        if (health <=50) //ü���� ���� �����ϋ�
        {
            GetComponent<Animator>().SetBool("BossEnrage",true);
        }
        if (health <=0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("���� ����");
        animator.SetTrigger("BossDead");
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        //gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
