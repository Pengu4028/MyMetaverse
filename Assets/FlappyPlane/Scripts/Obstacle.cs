using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f;
    public float lowPosY = -1f;

    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;

    public Transform TopObject;
    public Transform BottomObject;

    public float widthPadding = 4f;

    MinigameFlap.GameManager gameManager;

    private void Start()
    {
        gameManager = MinigameFlap.GameManager.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstaclCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2;

        TopObject.localPosition = new Vector3(0, halfHoleSize);
        BottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        MinigameFlap.Player player = collision.GetComponent<MinigameFlap.Player>();
        if (player != null)
        {
            Debug.Log("플레이어통과");
            gameManager.AddScore(1);
        }
    }

}
