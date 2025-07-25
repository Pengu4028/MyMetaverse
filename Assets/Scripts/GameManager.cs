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
        // �� ��ȯ �Ǵ� �̴ϰ��� UI Ȱ��ȭ
    }

    public void EndMinigame(int score)
    {
        Debug.Log("Minigame Ended. Score: " + score);
        // ���� ���� �� ��� ó��
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Current Score: " + score);
        // UI ���� ���� �� �߰� �۾� ����
    }

}
