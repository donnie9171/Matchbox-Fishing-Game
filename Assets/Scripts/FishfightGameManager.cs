using UnityEngine;

public class FishfightGameManager : MonoBehaviour
{
    float tensionGrowthRate = 5f; // Rate at which tension grows per second
    public float currentTension { get; private set; } // Current tension level
    float maxTension = 100f; // Maximum tension level before failure
    public GameObject playerManager; // Reference to the player manager
    public bool isFainted = false; // Flag to check if the fish is fainted

    float reductionHit = 20f; // Tension reduction on successful hit
    
    void OnEnable()
    {
        currentTension = 30f;
    }


    void Update()
    {
        if (isFainted) return; // If the fish is fainted, skip tension updates
        currentTension += tensionGrowthRate * Time.deltaTime; // Increase tension over time
        if (currentTension >= maxTension)
        {
            Debug.Log("Game Over: Tension exceeded maximum limit!");
            // Handle game over logic here, e.g., reset game or show game over screen
            currentTension = 0f; // Reset tension for simplicity in this example
            PlayerManager playerManagerClass = playerManager.GetComponent<PlayerManager>();
            playerManagerClass.takedamage(); // Call the damage method on the player manager
            playerManagerClass.OnFishFightExit();

        }
    }

    public void ReduceTension(float multiplier)
    {
        currentTension -= reductionHit*multiplier; // Reduce tension on successful hit
        if (currentTension < 0f)
        {
            currentTension = 0f; // Ensure tension doesn't go below zero
            isFainted = true; // Set fainted flag to true
        }
        Debug.Log("Tension reduced. Current Tension: " + currentTension);
    }


}
