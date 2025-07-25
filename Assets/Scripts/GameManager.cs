using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void StartMinigame(string name)
    {
        Debug.Log("Starting Minigame: " + name);
        // 씬 전환 또는 미니게임 UI 활성화
    }

    public void EndMinigame(int score)
    {
        Debug.Log("Minigame Ended. Score: " + score);
        // 점수 저장 및 결과 처리
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Current Score: " + score);
        // UI 점수 갱신 등 추가 작업 가능
    }

}
