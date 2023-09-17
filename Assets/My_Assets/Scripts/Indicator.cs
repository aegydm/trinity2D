using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public float transparencySpeed = 0.1f; // ������ �����ϴ� �ӵ�
    public float minTransparency = 0.2f;   // �ּ� ����
    public float maxTransparency = 0.8f;   // �ִ� ����

    private Material material; // ������Ʈ�� ����
    private bool increasing = true; // ������ ���� ������ ����
    private float currentTransparency; // ���� ����

    private void Start()
    {
        // ������Ʈ�� Renderer ������Ʈ�κ��� ������ ������
        Renderer renderer = GetComponent<Renderer>();
        material = renderer.material;

        // ������ �� �ּ� ������ ����
        currentTransparency = minTransparency;
        SetTransparency(currentTransparency);
    }

    private void Update()
    {
        // ������ ����
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

        // ����� ������ ������ ����
        SetTransparency(currentTransparency);
    }

    private void SetTransparency(float alpha)
    {
        Color color = material.color;
        color.a = alpha;
        material.color = color;
    }
}