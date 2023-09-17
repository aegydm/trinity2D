using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour
{
    private ParticleSystem particleSystem;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();

        // 파티클 재생이 시작되면 지속 시간 후에 자동으로 삭제됩니다.
        if (particleSystem != null)
        {
            Destroy(gameObject, particleSystem.main.duration);
        }
    }
}
