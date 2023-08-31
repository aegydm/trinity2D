using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyS : MonoBehaviour
{
    public float enemySSpeed = 7.0f;
    public int enemySHP = 1;
    Vector3 Sdirection;

    void Start()
    {
        Sdirection = Vector3.left;
    }

    void Update()
    {
        transform.Translate(Sdirection * enemySSpeed * Time.deltaTime);
        Destroy(gameObject ,3);
    }
}
