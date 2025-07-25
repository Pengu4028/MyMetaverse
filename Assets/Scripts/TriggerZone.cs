using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TriggerZone : MonoBehaviour
{
    public string targetObjectName = "FlapBox";
    public string targetObjectName2 = "GoldBox";
    public string targetObjectName3 = "StackBox";

    public string nextSceneName = "FlapScene";
    public string nextSceneName2 = "GoldScene";
    public string nextSceneName3 = "StackScene";

    public GameObject messageUI;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;

        if (other.gameObject.name == targetObjectName)
        {
            triggered = true;
            StartCoroutine(LoadSceneWithDelay(nextSceneName));
        }
        else if (other.gameObject.name == targetObjectName2)
        {
            triggered = true;
            StartCoroutine(LoadSceneWithDelay(nextSceneName2));
        }
        else if (other.gameObject.name == targetObjectName3)
        {
            triggered = true;
            StartCoroutine(LoadSceneWithDelay(nextSceneName3));
        }
    }

    IEnumerator LoadSceneWithDelay(string sceneName)
    {
        if (messageUI != null)
        {
            messageUI.SetActive(true);
        }

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(sceneName);
    }
}
