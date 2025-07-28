using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupTrigger : MonoBehaviour
{
    public GameObject balloonUI;

    private void Start()
    {
        if (balloonUI != null)
            balloonUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            balloonUI.SetActive(true);
            Animator animator = balloonUI.GetComponent<Animator>();
            if (animator != null)
                animator.Play("PopupShow", 0, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (balloonUI != null)
                balloonUI.SetActive(false);
        }
    }
}
