using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySMBullet : MonoBehaviour
{
    public float enemySMBulletSpeed = 14;
    public float enemySMBulletDMG = 0;

    Vector3 enemySMBulletDir;
    void Start()
    {
        enemySMBulletDir = Vector3.left;
    }

    void Update()
    {
        transform.Translate(enemySMBulletDir * enemySMBulletSpeed * Time.deltaTime);
        Destroy(gameObject, 3);
    }
}
