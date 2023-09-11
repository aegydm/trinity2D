using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySMBullet : MonoBehaviour
{
    [SerializeField] private float enemySMBulletSpeed = 14;
    [SerializeField] private float enemySMBulletDMG = 0;
    [SerializeField] private float enemySMBulletDestroy = 5;

    Vector3 enemySMBulletDir;
    void Start()
    {
        enemySMBulletDir = Vector3.left;
    }

    void Update()
    {
        transform.Translate(enemySMBulletDir * enemySMBulletSpeed * Time.deltaTime);
        Destroy(gameObject, enemySMBulletDestroy);
    }
}
