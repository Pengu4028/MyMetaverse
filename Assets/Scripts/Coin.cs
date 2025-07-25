using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    public int scoreValue = 1; // ����� 1, �ǹ� 5, ��� 10 �� ���� �� ����

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ���� �ø��� (��: GameManager�� ���� ���� �Լ� ȣ��)
            GameManager.Instance.AddScore(scoreValue);

            // ���� ����
            Destroy(gameObject);
        }
    }
}