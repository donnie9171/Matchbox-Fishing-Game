using UnityEngine;
using System.Collections;

public class SpriteSpawner : MonoBehaviour
{
    [Header("生成參數")]
    public GameObject[] spritePrefabs;     // 多個可生成的精靈預製物
    public int spawnCount = 3;             // 同時存在的精靈數量
    public float moveSpeed = 5f;           // 左移速度
    public float leftBoundary = -10f;      // 左邊界（超過此值就重設）
    public float rightSpawnX = 10f;        // 生成/重設時的X座標
    public float minY = -3f;               // 隨機Y座標下限
    public float maxY = 3f;                // 隨機Y座標上限
    public float spawnDelay = 2f;        // 每個物件生成的延遲（秒）

    private GameObject[] sprites;

    void Start()
    {
        sprites = new GameObject[spawnCount];
        StartCoroutine(SpawnWithDelay());
    }

    IEnumerator SpawnWithDelay()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            int prefabIndex = Random.Range(0, spritePrefabs.Length);
            Vector3 spawnPos = new Vector3(rightSpawnX, spritePrefabs[prefabIndex].transform.position.y, 0f);
            sprites[i] = Instantiate(spritePrefabs[prefabIndex], spawnPos, Quaternion.identity, transform);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void Update()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            if (sprites[i] == null) continue;

            // 左移
            sprites[i].transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            // 超過左邊界就重設到右側，Y隨機，並隨機換一個預製物
            if (sprites[i].transform.position.x < leftBoundary)
            {
                int prefabIndex = Random.Range(0, spritePrefabs.Length);

                Destroy(sprites[i]);
                sprites[i] = Instantiate(spritePrefabs[prefabIndex], new Vector3(rightSpawnX, spritePrefabs[prefabIndex].transform.position.y, 0f), Quaternion.identity, transform);
            }
        }
    }
}
