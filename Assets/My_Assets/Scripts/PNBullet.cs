using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNBullet : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 dir = Vector3.right;

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;

        if (transform.position.x > 11)
        {
            speed = 10f;
            gameObject.SetActive(false);
        }

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    gameObject.SetActive(false);
    //    Debug.Log("총알 비활성화");
    //}
}
