using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject[] coinPrefabs; // 브론즈, 실버, 골드 프리팹 배열
    public int coinCount = 30;       // 맵에 뿌릴 동전 총 개수
    public Vector2 mapMin;           // 맵 최소 좌표 (예: 왼쪽 하단)
    public Vector2 mapMax;           // 맵 최대 좌표 (예: 오른쪽 상단)

    void Start()
    {
        SpawnCoins();
    }

    void SpawnCoins()
    {
        for (int i = 0; i < coinCount; i++)
        {

            if (coinPrefabs.Length == 0)
            {
                Debug.LogWarning("coinPrefabs 배열이 비어 있습니다!");
                return;
            }

            // coinPrefabs 중 랜덤 선택
            int index = Random.Range(0, coinPrefabs.Length);
            GameObject coin = coinPrefabs[index];

            // 랜덤 위치 생성
            float x = Random.Range(mapMin.x, mapMax.x);
            float y = Random.Range(mapMin.y, mapMax.y);
            Vector2 pos = new Vector2(x, y);

            // 동전 생성
            Instantiate(coin, pos, Quaternion.identity);
        }
    }
}