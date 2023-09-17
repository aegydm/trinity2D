using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public float transparencySpeed = 0.1f; // 투명도를 변경하는 속도
    public float minTransparency = 0.2f;   // 최소 투명도
    public float maxTransparency = 0.8f;   // 최대 투명도

    private Material material; // 오브젝트의 재질
    private bool increasing = true; // 투명도가 증가 중인지 여부
    private float currentTransparency; // 현재 투명도

    private void Start()
    {
        // 오브젝트의 Renderer 컴포넌트로부터 재질을 가져옴
        Renderer renderer = GetComponent<Renderer>();
        material = renderer.material;

        // 시작할 때 최소 투명도로 설정
        currentTransparency = minTransparency;
        SetTransparency(currentTransparency);
    }

    private void Update()
    {
        // 투명도를 변경
        if (increasing)
        {
            currentTransparency += transparencySpeed * Time.deltaTime;
            if (currentTransparency >= maxTransparency)
            {
                currentTransparency = maxTransparency;
                increasing = false;
            }
        }
        else
        {
            currentTransparency -= transparencySpeed * Time.deltaTime;
            if (currentTransparency <= minTransparency)
            {
                currentTransparency = minTransparency;
                increasing = true;
            }
        }

        // 변경된 투명도를 재질에 설정
        SetTransparency(currentTransparency);
    }

    private void SetTransparency(float alpha)
    {
        Color color = material.color;
        color.a = alpha;
        material.color = color;
    }
}