using UnityEngine;
using System.Collections;

public class SpriteSpawner : MonoBehaviour
{
    [Header("�ͦ��Ѽ�")]
    public GameObject[] spritePrefabs;     // �h�ӥi�ͦ������F�w�s��
    public int spawnCount = 3;             // �P�ɦs�b�����F�ƶq
    public float moveSpeed = 5f;           // �����t��
    public float leftBoundary = -10f;      // ����ɡ]�W�L���ȴN���]�^
    public float rightSpawnX = 10f;        // �ͦ�/���]�ɪ�X�y��
    public float minY = -3f;               // �H��Y�y�ФU��
    public float maxY = 3f;                // �H��Y�y�ФW��
    public float spawnDelay = 2f;        // �C�Ӫ���ͦ�������]��^

    public bool isPaused = false; // �O�_�Ȱ��ͦ��M����
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
        if(isPaused || isGameOver) return; // �p�G�Ȱ��A�h�������s�޿�
        
        for (int i = 0; i < sprites.Length; i++)
        {
            if (sprites[i] == null) continue;

            // ����
            sprites[i].transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            // �W�L����ɴN���]��k���A���H�����@�ӹw�s��
            if (sprites[i].transform.position.x < leftBoundary)
            {
                if(sprites[i].CompareTag("Fish"))
                {
                    // �p�G�O���A�h�H��Y�y��
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
        if (isPaused) return; // �p�G�Ȱ��A�h�����歫���޿�
        StartCoroutine(RespawnFishWithDelay());
    }

    private IEnumerator RespawnFishWithDelay()
    {
        yield return new WaitForSeconds(2f);
        // �H���ͦ�����Y�y��
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
                sprite.SetActive(false); // ���éҦ��ͦ�������
            }
        }
    }

    private void ShowAllObjects()
    {
        foreach (GameObject sprite in sprites)
        {
            if (sprite != null)
            {
                sprite.SetActive(true); // ��ܩҦ��ͦ�������
            }
        }
    }



    public void PauseSpawning()
    {
        isPaused = true; // �Ȱ��ͦ��M����
        HideAllObjects();
    }

    public void ResumeSpawning()
    {
        isPaused = false; // ��_�ͦ��M����
        ShowAllObjects();
    }
}
