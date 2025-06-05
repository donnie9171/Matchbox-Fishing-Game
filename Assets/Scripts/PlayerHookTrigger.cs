using UnityEngine;

public class PlayerHookTrigger : MonoBehaviour
{
    
    public PlayerManager playerManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ��P����2DĲ�o���I���ɩI�s
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Fish") || other.gameObject.CompareTag("Obstacle"))
        {
            HandleCollision(other);
        }
        
    }

    void HandleCollision(Collider2D other)
    {
        // �b�o�̳B�z�I���޿�A�Ҧp�R�����λ�ê��
        if (other.gameObject.CompareTag("Fish"))
        {
            Destroy(other.gameObject); // �R��������
            Debug.Log("Caught a fish!");
            playerManager.OnFishFightEnter(); // �I�s PlayerManager �� OnFishFightEnter ��k
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Hit");
            playerManager.takedamage(); // �I�s PlayerManager �� takedamage ��k
            int currentLifeCount = playerManager.currentlifeCount;
            
        }
    }
}
