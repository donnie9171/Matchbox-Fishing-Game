using UnityEngine;

public class FishPullingFunction : MonoBehaviour
{
    public FishfightGameManager fishfightGameManager;
    public void FishPulling() {         // Implement the logic for pulling the fish here
        fishfightGameManager.fishpulling();
    }

    public bool IsFainted() {
        return fishfightGameManager.isFainted; // Return the fainted state from FishfightGameManager
    }
}
