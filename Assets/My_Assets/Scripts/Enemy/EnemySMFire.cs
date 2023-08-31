using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySMFire : MonoBehaviour
{
    public GameObject enemySMBullet;
    public GameObject gun;

    public float fireRate = 3.0f;
    private float currentTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        
        if( currentTime > fireRate)
        {
            GameObject _enemySMBullet = Instantiate(enemySMBullet);
            _enemySMBullet.transform.position = gun.transform.position;

            currentTime = 0;
        }
        
    }
}
