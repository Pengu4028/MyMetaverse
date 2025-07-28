using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject[] coinPrefabs; // �����, �ǹ�, ��� ������ �迭
    public int coinCount = 30;       // �ʿ� �Ѹ� ���� �� ����
    public Vector2 mapMin;           // �� �ּ� ��ǥ (��: ���� �ϴ�)
    public Vector2 mapMax;           // �� �ִ� ��ǥ (��: ������ ���)

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
                Debug.LogWarning("coinPrefabs �迭�� ��� �ֽ��ϴ�!");
                return;
            }

            // coinPrefabs �� ���� ����
            int index = Random.Range(0, coinPrefabs.Length);
            GameObject coin = coinPrefabs[index];

            // ���� ��ġ ����
            float x = Random.Range(mapMin.x, mapMax.x);
            float y = Random.Range(mapMin.y, mapMax.y);
            Vector2 pos = new Vector2(x, y);

            // ���� ����
            Instantiate(coin, pos, Quaternion.identity);
        }
    }
}