using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject PNBullet;
    public GameObject PGunPos;
    public int BulletNum;
    public float fireRate = 1.0f;
    private float fireRateDelay = 0f;

    public int poolSize = 30;      //źâ
    public List<GameObject> PNBPool;

    // Start is called before the first frame update
    void Start()
    {
        PNBPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject PNBulletGO = Instantiate(PNBullet);

            //PNBulletGO.transform.parent = transform;

            PNBPool.Add(PNBulletGO);
            PNBulletGO.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (fireRateDelay > 0)
            {
                fireRateDelay -= Time.deltaTime;
            }
            else
            {
                BulletNumber0();
                fireRateDelay = fireRate; 
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            fireRateDelay = 0;
        }
        
    }
    //public void BulletNumber()
    //{
    //    switch (BulletNum)
    //    {
    //        case 0:
    //            BulletNumber0();
    //            break;
    //        case 1:
    //            BulletNumber1();
    //            break;
    //        case 2:
    //            BulletNumber2();
    //            break;
    //    }
    //}

    void BulletNumber0()
    {
        if (PNBPool.Count > 0)
        {
            GameObject PNBulletGO = PNBPool[0];

            PNBulletGO.SetActive(true);

            PNBulletGO.transform.position = PGunPos.transform.position + new Vector3(0, 0, 0);

            PNBPool.Remove(PNBulletGO);
            PNBPool.Add(PNBulletGO);

        }
    }
    //void BulletNumber1()
    //{
    //    if (PNBPool.Count > 0)
    //    {
    //        GameObject PNBulletGO = PNBPool[0];

    //        PNBulletGO.SetActive(true);

    //        PNBulletGO.transform.position = PGunPos.transform.position + new Vector3(0, -0.2f, 0);

    //        PNBPool.Remove(PNBulletGO);
    //    }
    //    if (PNBPool.Count > 0)
    //    {
    //        GameObject PNBulletGO = PNBPool[0];

    //        PNBulletGO.SetActive(true);

    //        PNBulletGO.transform.position = PGunPos.transform.position + new Vector3(0, 0.2f, 0);

    //        PNBPool.Remove(PNBulletGO);
    //    }
    //}
    //void BulletNumber2()
    //{
    //    if (PNBPool.Count > 0)
    //    {
    //        GameObject PNBulletGO = PNBPool[0];

    //        PNBulletGO.SetActive(true);

    //        PNBulletGO.transform.position = PGunPos.transform.position + new Vector3(0, 0.2f, 0);
    //        PNBulletGO.transform.rotation = Quaternion.Euler(0, 0, 20);
    //        PNBulletGO.GetComponent<PNBullet>().dir = PNBulletGO.transform.right;
    //        PNBPool.Remove(PNBulletGO);
    //    }
    //    if (PNBPool.Count > 0)
    //    {
    //        GameObject PNBulletGO = PNBPool[0];

    //        PNBulletGO.SetActive(true);

    //        PNBulletGO.transform.position = PGunPos.transform.position + new Vector3(0, 0f, 0);

    //        PNBPool.Remove(PNBulletGO);
    //    }
    //    if (PNBPool.Count > 0)
    //    {
    //        GameObject PNBulletGO = PNBPool[0];

    //        PNBulletGO.SetActive(true);

    //        PNBulletGO.transform.position = PGunPos.transform.position + new Vector3(0, -0.2f, 0);
    //        PNBulletGO.transform.rotation = Quaternion.Euler(0, 0, -20);
    //        PNBulletGO.GetComponent<PNBullet>().dir = PNBulletGO.transform.right;
    //        PNBPool.Remove(PNBulletGO);
    //    }

    //}
}
