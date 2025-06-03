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

    // ��P����2DĲ�o���I���ɩI�s
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit");
        playerManager.takedamage(); // �I�s PlayerManager �� takedamage ��k
        int currentLifeCount = playerManager.currentlifeCount;
        hookLeftUI.SetLifeCount(currentLifeCount, playerManager.maxlifeCount);


    }
}
