using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRoller : MonoBehaviour
{
    // 속성: 현재시간, 속도
    float currentTime;
    public float speed = 1;
    public Material material;

    // Update is called once per frame
    void Update()
    {
        currentTime += speed * Time.deltaTime;

        material.mainTextureOffset = Vector3.right * currentTime;

    }
}
