using System;
using UnityEngine;

public class FishfightGameManager : MonoBehaviour
{
    float tensionGrowthRate = 3f; // Rate at which tension grows per second
    public float currentTension { get; private set; } // Current tension level
    float maxTension = 100f; // Maximum tension level before failure
    public GameObject playerManager; // Reference to the player manager
    public GameObject fishPulling; // Reference to the fish pulling function

    public GameObject YankUI;
    public GameObject HookUI;

    public TipsVisual TipsVisual;
    public DepthUIVisual DepthUIVisual;
    public bool isFainted = false; // Flag to check if the fish is fainted

    float reductionHit = 30f; // Tension reduction on successful hit

    public float initialDepth = 50f; // Initial depth of the fish

    // �s�W timer ���
    private float timer = 0f;

    // �b OnEnable ��l�� timer
    void OnEnable()
    {
        currentTension = 30f;
        isFainted = false;
        initialDepth = 50f;
        timer = 0f;
    }

    // �b Update ��k���֥[ timer
    void Update()
    {
        timer += Time.deltaTime;
        updateTips();
        if (isFainted)
        {
            if (initialDepth < 0f)
            {
                initialDepth = 0f;
                PlayerManager playerManagerClass = playerManager.GetComponent<PlayerManager>();
                playerManagerClass.CatchFish(timer);
            }
            return; // If the fish is fainted, skip tension updates
        }
        currentTension += tensionGrowthRate * Time.deltaTime; // Increase tension over time
        if (currentTension >= maxTension)
        {
            Debug.Log("Game Over: Tension exceeded maximum limit!");
            // Handle game over logic here, e.g., reset game or show game over screen
            currentTension = 0f; // Reset tension for simplicity in this example
            PlayerManager playerManagerClass = playerManager.GetComponent<PlayerManager>();
            playerManagerClass.FishGotAway();
        }
    }

    // �i��G�s�W�@�Ӥ�k���o timer
    public float GetTimer()
    {
        return timer;
    }

    private void updateTips()
    {
        TipsVisual.IsFainted(isFainted); // Update the tips visual based on fainted state
        DepthUIVisual.UpdateDepth(initialDepth); // Update the depth UI visual
        if (isFainted)
        {
            YankUI.SetActive(false);
            HookUI.SetActive(true);
        }
        else
        {
            YankUI.SetActive(true);
            HookUI.SetActive(false);
        }
    }

    public void ReduceTension(float multiplier)
    {
        currentTension -= reductionHit*multiplier; // Reduce tension on successful hit
        if (currentTension < 0f)
        {
            currentTension = 0f; // Ensure tension doesn't go below zero
            isFainted = true; // Set fainted flag to true
            fishPulling.SetActive(true); // Activate the fish pulling function
            
        }
    }

    public void fishpulling()
    {
        if (!isFainted) return;

        initialDepth -= 1f;

    }


}
