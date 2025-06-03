using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int maxlifeCount = 3; // 初始生命數量
    public bool isGameOver = false; // 遊戲是否結束
    public bool isFightingWithFish = false; // 是否正在與魚戰鬥

    public GameObject canvasManagerRef; // 參考 CanvasManager

    public int currentFishCount = 0; // 當前魚的數量
    public int currentlifeCount = 3; 

    void Start()
    {
        currentlifeCount = maxlifeCount; // 初始化當前生命數量
        LifeCountList lifeCountList = canvasManagerRef.GetComponentInChildren<LifeCountList>();
        lifeCountList.PopulateUIList(maxlifeCount); // 設置生命數量UI
        lifeCountList.SetLifeCount(currentlifeCount, maxlifeCount); // 初始化生命數量UI顯示
    }
    public void takedamage()
    {
        if (isGameOver) return; // 如果遊戲已經結束，則不處理傷害
        currentlifeCount--; // 減少生命數量
        if (currentlifeCount <= 0)
        {
            currentlifeCount = 0;
            isGameOver = true; // 如果生命數量小於等於0，則遊戲結束
            Debug.Log("Game Over!");
            canvasManagerRef.GetComponent<CanvasManager>().GameOver(); // 呼叫 CanvasManager 的 GameOver 方法
        }
    }
}
