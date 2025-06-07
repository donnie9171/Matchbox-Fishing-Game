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
    private LifeCountList lifeCountList; // 用於顯示生命數量的 UI

    public GameObject fishfightManager;

    public int currentFishCount = 0; // 當前魚的數量
    public int currentlifeCount = 3; 

    void Start()
    {
        canvasManager = canvasManagerRef.GetComponent<CanvasManager>(); // 獲取 CanvasManager 的實例
        canvasManager.Init(); // 初始化 CanvasManager
        canvasManager.ResetGame(); // 啟用初始畫布
        isGameOver = false; // 初始化遊戲狀態

        currentlifeCount = maxlifeCount; // 初始化當前生命數量
        lifeCountList = canvasManagerRef.GetComponentInChildren<LifeCountList>();
        lifeCountList.PopulateUIList(maxlifeCount); // 設置生命數量UI
        lifeCountList.SetLifeCount(currentlifeCount, maxlifeCount); // 初始化生命數量UI顯示

        fishfightManager.SetActive(false); // 確保魚戰鬥管理器初始為不活動狀態

        spriteSpawner.StartSpawningObstacles(); // 開始生成障礙物
    }
    public void takedamage()
    {
        if (isGameOver) return; // 如果遊戲已經結束，則不處理傷害
        currentlifeCount--; // 減少生命數量
        lifeCountList.SetLifeCount(currentlifeCount, maxlifeCount);
        if (currentlifeCount <= 0)
        {
            currentlifeCount = 0;
            isGameOver = true; // 如果生命數量小於等於0，則遊戲結束
            Debug.Log("Game Over!");
            canvasManager.GameOver(); // 呼叫 CanvasManager 的 GameOver 方法
            spriteSpawner.isGameOver = true; // 停止生成障礙物
        }
    }

    public void OnFishFightEnter()
    {
        if (isFightingWithFish) return; // 如果已經在與魚戰鬥，則不處理
        spriteSpawner.PauseSpawning();
        playerhookRef.SetActive(false); // 隱藏魚鉤

        isFightingWithFish = true; // 設置正在與魚戰鬥的狀態
        canvasManager.StartFight(); // 呼叫 CanvasManager 的 StartFight 方法
        fishfightManager.SetActive(true); // 啟用魚戰鬥管理器
    }

    public void OnFishFightExit()
    {
        if (!isFightingWithFish) return; // 如果沒有在與魚戰鬥，則不處理
        if(currentlifeCount <= 0) return; // 如果生命數量小於等於0，則不處理
        spriteSpawner.ResumeSpawning();
        spriteSpawner.Respawnfish();

        fishfightManager.SetActive(false);
        playerhookRef.SetActive(true); // 顯示魚鉤
        isFightingWithFish = false; // 重置正在與魚戰鬥的狀態
        canvasManager.ResetGame(); // 呼叫 CanvasManager 的 ResetGame 方法
    }

    public void CatchFish()
    {
        if (isGameOver) return; // 如果遊戲已經結束，則不處理捕魚
        currentFishCount++; // 增加捕獲的魚數量
        canvasManager.FishCatched(); // 呼叫 CanvasManager 的 FishCatched 方法
        StartCoroutine(WaitAndExitFishFight());
    }

    public void FishGotAway()
    {
        if (isGameOver) return; // 如果遊戲已經結束，則不處理魚逃脫
        canvasManager.FishGotAway(); // 呼叫 CanvasManager 的 FishGotAway 方法
        StartCoroutine(WaitAndExitFishFight());
    }

    private System.Collections.IEnumerator WaitAndExitFishFight()
    {
        yield return new WaitForSeconds(5f);
        OnFishFightExit();
    }
}
