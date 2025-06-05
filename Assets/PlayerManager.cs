using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int maxlifeCount = 3; // 初始生命數量
    public bool isGameOver; // 遊戲是否結束
    public bool isFightingWithFish = false; // 是否正在與魚戰鬥

    public GameObject canvasManagerRef; // 參考 CanvasManager\
    public GameObject playerhookRef;
    private CanvasManager canvasManager; // CanvasManager 的實例
    public SpriteSpawner spriteSpawner;

    public int currentFishCount = 0; // 當前魚的數量
    public int currentlifeCount = 3; 

    void Start()
    {
        canvasManager = canvasManagerRef.GetComponent<CanvasManager>(); // 獲取 CanvasManager 的實例
        canvasManager.Init(); // 初始化 CanvasManager
        canvasManager.ResetGame(); // 啟用初始畫布
        isGameOver = false; // 初始化遊戲狀態

        currentlifeCount = maxlifeCount; // 初始化當前生命數量
        LifeCountList lifeCountList = canvasManagerRef.GetComponentInChildren<LifeCountList>();
        lifeCountList.PopulateUIList(maxlifeCount); // 設置生命數量UI
        lifeCountList.SetLifeCount(currentlifeCount, maxlifeCount); // 初始化生命數量UI顯示

        spriteSpawner.StartSpawningObstacles(); // 開始生成障礙物
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
            canvasManager.GameOver(); // 呼叫 CanvasManager 的 GameOver 方法
        }
    }

    public void OnFishFightEnter()
    {
        if (isFightingWithFish) return; // 如果已經在與魚戰鬥，則不處理
        spriteSpawner.PauseSpawning();
        playerhookRef.SetActive(false); // 隱藏魚鉤

        isFightingWithFish = true; // 設置正在與魚戰鬥的狀態
        canvasManager.StartFight(); // 呼叫 CanvasManager 的 StartFight 方法

    }
}
