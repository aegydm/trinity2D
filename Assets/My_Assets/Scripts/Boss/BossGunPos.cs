using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGunPos : MonoBehaviour
{
    public float moveSpeed = 2.0f; // ������Ʈ�� �����̴� �ӵ�
    public float moveDistance = 2.0f; // �� �Ʒ��� �����̴� ������ ���� ũ��

    private Vector3 initialPosition;
    private float direction = 1.0f; // ������Ʈ�� �����̴� ���� (����: 1, �Ʒ���: -1)
    private bool isMoving = false; // ������Ʈ�� �����̴��� ���θ� ��Ÿ���� �÷���

    private void Start()
    {
        initialPosition = transform.position;
        StartCoroutine(StartMovingAfterDelay(2.0f)); // ó�� 2�� ���� �������� ����
    }

    private void Update()
    {
        if (isMoving)
        {
            // �� �����Ӹ��� ������Ʈ�� �� �Ʒ��� �����Դϴ�.
            float newYPosition = initialPosition.y + direction * moveDistance * Mathf.Sin(Time.time * moveSpeed);
            transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
        }
    }

    private IEnumerator StartMovingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isMoving = true; // ������ ����
    }
}
