using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 dir = Vector3.left;

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("�����ݸ��� ����");
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("�������� ����");
            Destroy(gameObject);
        }
    }
}
