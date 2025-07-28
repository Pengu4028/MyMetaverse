using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    //안씀!! // 박스에서 다이렉트로 인터랙션 진행
    //public void StartInteraction(GameObject obj)
    //{
    //    Debug.Log("Interacting with: " + obj.name);
    //    // 오브젝트에 따라 미니게임 실행, 대화 등 처리
    //}
}
