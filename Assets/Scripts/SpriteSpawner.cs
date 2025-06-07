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

    public bool isPaused = false; // 是否暫停生成和移動
    public bool isGameOver = false;

    private GameObject[] sprites;

    public void StartSpawningObstacles()
    {
        sprites = new GameObject[spawnCount];
        StartCoroutine(SpawnWithDelay());

    }

    IEnumerator SpawnWithDelay()
    {
        for (int i = 0; i < spawnCount-1; i++)
        {
            if (isPaused) continue; 
            
            int prefabIndex = Random.Range(0, spritePrefabs.Length-1);
            Vector3 spawnPos = new Vector3(rightSpawnX, spritePrefabs[prefabIndex].transform.position.y, 0f);
            sprites[i] = Instantiate(spritePrefabs[prefabIndex], spawnPos, Quaternion.identity, transform);
            yield return new WaitForSeconds(spawnDelay);
        }
        //spwanfish
        Vector3 spawnPos2 = new Vector3(rightSpawnX, Random.Range(minY, maxY), 0f);
        sprites[spawnCount - 1] = Instantiate(spritePrefabs[spritePrefabs.Length - 1], spawnPos2, Quaternion.identity, transform);
    }

    void Update()
    {
        if(isPaused || isGameOver) return; // 如果暫停，則不執行更新邏輯
        
        for (int i = 0; i < sprites.Length; i++)
        {
            if (sprites[i] == null) continue;

            // 左移
            sprites[i].transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            // 超過左邊界就重設到右側，並隨機換一個預製物
            if (sprites[i].transform.position.x < leftBoundary)
            {
                if(sprites[i].CompareTag("Fish"))
                {
                    // 如果是魚，則隨機Y座標
                    sprites[i].transform.position = new Vector3(rightSpawnX, Random.Range(minY, maxY), 0f);
                }
                else
                {
                    int prefabIndex = Random.Range(0, spritePrefabs.Length - 1);

                    Destroy(sprites[i]);
                    sprites[i] = Instantiate(spritePrefabs[prefabIndex], new Vector3(rightSpawnX, spritePrefabs[prefabIndex].transform.position.y, 0f), Quaternion.identity, transform);
                }
                
            }
        }
    }

    public void Respawnfish()
    {
        if (isPaused) return; // 如果暫停，則不執行重生邏輯
        StartCoroutine(RespawnFishWithDelay());
    }

    private IEnumerator RespawnFishWithDelay()
    {
        yield return new WaitForSeconds(2f);
        // 隨機生成魚的Y座標
        Vector3 spawnPos = new Vector3(rightSpawnX, Random.Range(minY, maxY), 0f);
        GameObject newFish = Instantiate(spritePrefabs[spritePrefabs.Length - 1], spawnPos, Quaternion.identity, transform);
        sprites[sprites.Length - 1] = newFish;
    }

    private void HideAllObjects()
    {
        foreach (GameObject sprite in sprites)
        {
            if (sprite != null)
            {
                sprite.SetActive(false); // 隱藏所有生成的物件
            }
        }
    }

    private void ShowAllObjects()
    {
        foreach (GameObject sprite in sprites)
        {
            if (sprite != null)
            {
                sprite.SetActive(true); // 顯示所有生成的物件
            }
        }
    }



    public void PauseSpawning()
    {
        isPaused = true; // 暫停生成和移動
        HideAllObjects();
    }

    public void ResumeSpawning()
    {
        isPaused = false; // 恢復生成和移動
        ShowAllObjects();
    }
}
