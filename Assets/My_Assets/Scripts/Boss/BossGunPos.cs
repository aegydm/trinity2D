using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGunPos : MonoBehaviour
{
    public float moveSpeed = 2.0f; // 오브젝트의 움직이는 속도
    public float moveDistance = 2.0f; // 위 아래로 움직이는 범위의 반쪽 크기

    private Vector3 initialPosition;
    private float direction = 1.0f; // 오브젝트가 움직이는 방향 (위로: 1, 아래로: -1)
    private bool isMoving = false; // 오브젝트가 움직이는지 여부를 나타내는 플래그

    private void Start()
    {
        initialPosition = transform.position;
        StartCoroutine(StartMovingAfterDelay(2.0f)); // 처음 2초 동안 움직이지 않음
    }

    private void Update()
    {
        if (isMoving)
        {
            // 매 프레임마다 오브젝트를 위 아래로 움직입니다.
            float newYPosition = initialPosition.y + direction * moveDistance * Mathf.Sin(Time.time * moveSpeed);
            transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
        }
    }

    private IEnumerator StartMovingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isMoving = true; // 움직임 시작
    }
}
