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

    //�Ⱦ�!!
    //public void StartInteraction(GameObject obj)
    //{
    //    Debug.Log("Interacting with: " + obj.name);
    //    // ������Ʈ�� ���� �̴ϰ��� ����, ��ȭ �� ó��
    //}
}
