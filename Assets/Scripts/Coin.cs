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
            if (Main.GameManager.Instance != null)
            {
                Main.GameManager.Instance.AddScore(scoreValue);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("GameManager.Instance is null in Coin!");
            }
        }
    }
}