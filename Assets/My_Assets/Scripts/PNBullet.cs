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
        
    }
}
