using UnityEngine;

public class PlayerHookTrigger : MonoBehaviour
{
    public LifeCountList hookLeftUI;
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
        Debug.Log("Hit");
        playerManager.takedamage(); // 呼叫 PlayerManager 的 takedamage 方法
        int currentLifeCount = playerManager.currentlifeCount;
        hookLeftUI.SetLifeCount(currentLifeCount, playerManager.maxlifeCount);


    }
}
