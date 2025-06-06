using UnityEngine;

public class FishBossState : MonoBehaviour
{
    public enum FishState { Normal, Angry, Faint }

    public FishSpriteController fishSpriteController; // 指定 FishSpriteController
    public FishfightGameManager fishfightGameManager; // 指定 FishfightGameManager

    public FishState currentState = FishState.Normal;
    private float stateTimer = 0f;
    private float faintDuration = 5f;
    private float nextStateDuration = 0f;

    void Start()
    {
        if (fishSpriteController == null)
            fishSpriteController = GetComponent<FishSpriteController>();

        EnterNormalState();
    }

    void Update()
    {
        // 檢查是否需要進入 Faint 狀態
        if (currentState != FishState.Faint && fishfightGameManager.isFainted)
        {
            EnterFaintState();
            return;
        }

        stateTimer += Time.deltaTime;

        switch (currentState)
        {
            case FishState.Normal:
                if (stateTimer >= nextStateDuration)
                {
                    EnterAngryState();
                }
                break;
            case FishState.Angry:
                if (stateTimer >= nextStateDuration)
                {
                    EnterNormalState();
                }
                break;
            case FishState.Faint:
                if (stateTimer >= faintDuration)
                {
                    fishfightGameManager.isFainted = false; // Reset fainted state
                    EnterNormalState();
                }
                break;
        }
    }

    void EnterNormalState()
    {
        currentState = FishState.Normal;
        stateTimer = 0f;
        nextStateDuration = Random.Range(5f, 10f);
        fishSpriteController.SetNormalSprite();
    }

    void EnterAngryState()
    {
        currentState = FishState.Angry;
        stateTimer = 0f;
        nextStateDuration = Random.Range(5f, 10f);
        fishSpriteController.SetAngrySprite();
    }

    void EnterFaintState()
    {
        currentState = FishState.Faint;
        stateTimer = 0f;
        fishSpriteController.SetFaintSprite();
    }
}
