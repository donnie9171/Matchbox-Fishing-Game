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

            // ����
            sprites[i].transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            // �W�L����ɴN���]��k���AY�H���A���H�����@�ӹw�s��
            if (sprites[i].transform.position.x < leftBoundary)
            {
                int prefabIndex = Random.Range(0, spritePrefabs.Length);

                Destroy(sprites[i]);
                sprites[i] = Instantiate(spritePrefabs[prefabIndex], new Vector3(rightSpawnX, spritePrefabs[prefabIndex].transform.position.y, 0f), Quaternion.identity, transform);
            }
        }
    }
}
