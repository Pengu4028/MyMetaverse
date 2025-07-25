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
            // 점수 올리기 (예: GameManager에 점수 증가 함수 호출)
            GameManager.Instance.AddScore(scoreValue);

            // 동전 제거
            Destroy(gameObject);
        }
    }
}