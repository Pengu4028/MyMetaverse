using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    public int scoreValue = 1; // 브론즈 1, 실버 5, 골드 10 등 점수 값 조절

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