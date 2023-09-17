using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour
{
    private ParticleSystem particleSystem;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();

        // ��ƼŬ ����� ���۵Ǹ� ���� �ð� �Ŀ� �ڵ����� �����˴ϴ�.
        if (particleSystem != null)
        {
            Destroy(gameObject, particleSystem.main.duration);
        }
    }
}
