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

    // 當與任何2D觸發器碰撞時呼叫
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Fish") || other.gameObject.CompareTag("Obstacle"))
        {
            HandleCollision(other);
        }
        
    }

    void HandleCollision(Collider2D other)
    {
        // 在這裡處理碰撞邏輯，例如摧毀魚或障礙物
        if (other.gameObject.CompareTag("Fish"))
        {
            Destroy(other.gameObject); // 摧毀魚物件
            Debug.Log("Caught a fish!");
            playerManager.OnFishFightEnter(); // 呼叫 PlayerManager 的 OnFishFightEnter 方法
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Hit");
            playerManager.takedamage(); // 呼叫 PlayerManager 的 takedamage 方法
            int currentLifeCount = playerManager.currentlifeCount;
            
        }
    }
}
