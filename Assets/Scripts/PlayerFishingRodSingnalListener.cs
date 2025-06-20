using UnityEngine;

public class PlayerFishingRodSingnalListener : MonoBehaviour
{
    public PlayerControl playerControl; // Reference to the PlayerControl script
    public GameObject playerFishingRod;
    public FishPullingFunction fishPullingFunction; // Reference to the FishPullingFunction script
    private FishingRodSignalState currentSignalState = FishingRodSignalState.None;
    public bool isFainted = false; // Flag to check if the fish is fainted


    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Pressed 1");
            SwitchStateForInput(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("Pressed 2");
            SwitchStateForInput(2);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Pressed 3");
            SwitchStateForInput(3);
        }
        if (Input.GetKeyDown(KeyCode.End))
        {
            Debug.Log("Pressed 4");
            SwitchStateForInput(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Debug.Log("Pressed 5");
            SwitchStateForInput(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8)) 
        {
            SwitchStateForInput(6);

        }
        
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll == 0f) return;
        if (fishPullingFunction.IsFainted()) fishPullingFunction.FishPulling();
        if (scroll > 0f)
        {
            playerControl.Move(1);
        }
        else if (scroll < 0f)
        {
            playerControl.Move(-1);
        }
    }
    private void SwitchStateForInput(int inputNumber)
    {

        switch (inputNumber)
        {
            case 1:
                if(currentSignalState == FishingRodSignalState.Pressed1)
                {
                    
                    return; // Ignore if already in Pressed1 state
                }
                if(currentSignalState == FishingRodSignalState.Pressed2)
                {
                    playerControl.Move(-1);
                } else if (currentSignalState == FishingRodSignalState.Pressed5)
                {
                    playerControl.Move(1);
                    Debug.Log("Pressed 1, currentSignalState: "+ fishPullingFunction.IsFainted().ToString());
                    if (fishPullingFunction.IsFainted()) fishPullingFunction.FishPulling();
                }
                currentSignalState = FishingRodSignalState.Pressed1;
                break;
            case 2:
                if (currentSignalState == FishingRodSignalState.Pressed2)
                {

                    return; // Ignore if already in Pressed1 state
                }
                if (currentSignalState == FishingRodSignalState.Pressed3)
                {
                    playerControl.Move(-1);
                }
                else if (currentSignalState == FishingRodSignalState.Pressed1)
                {
                    playerControl.Move(1);
                    if (fishPullingFunction.IsFainted()) fishPullingFunction.FishPulling();
                }
                currentSignalState = FishingRodSignalState.Pressed2;
                break;
            case 3:
                if (currentSignalState == FishingRodSignalState.Pressed3)
                {

                    return; // Ignore if already in Pressed1 state
                }
                if (currentSignalState == FishingRodSignalState.Pressed4)
                {
                    playerControl.Move(-1);
                }
                else if (currentSignalState == FishingRodSignalState.Pressed2)
                {
                    playerControl.Move(1);
                    if (fishPullingFunction.IsFainted()) fishPullingFunction.FishPulling();
                }
                currentSignalState = FishingRodSignalState.Pressed3;
                break;
            case 4:
                if (currentSignalState == FishingRodSignalState.Pressed4)
                {

                    return; // Ignore if already in Pressed1 state
                }
                if (currentSignalState == FishingRodSignalState.Pressed5)
                {
                    playerControl.Move(-1);
                }
                else if (currentSignalState == FishingRodSignalState.Pressed3)
                {
                    playerControl.Move(1);
                    if (fishPullingFunction.IsFainted()) fishPullingFunction.FishPulling();
                }
                currentSignalState = FishingRodSignalState.Pressed4;
                break;
            case 5:
                if (currentSignalState == FishingRodSignalState.Pressed5)
                {

                    return; // Ignore if already in Pressed1 state
                }
                if (currentSignalState == FishingRodSignalState.Pressed6)
                {
                    playerControl.Move(-1);
                }
                else if (currentSignalState == FishingRodSignalState.Pressed4)
                {
                    playerControl.Move(1);
                    if (fishPullingFunction.IsFainted()) fishPullingFunction.FishPulling();
                }
                currentSignalState = FishingRodSignalState.Pressed5;
                break;
            case 6:
                if (currentSignalState == FishingRodSignalState.Pressed6)
                {

                    return; // Ignore if already in Pressed1 state
                }
                if (currentSignalState == FishingRodSignalState.Pressed1)
                {
                    playerControl.Move(-1);
                }
                else if (currentSignalState == FishingRodSignalState.Pressed5)
                {
                    playerControl.Move(1);
                    if (fishPullingFunction.IsFainted()) fishPullingFunction.FishPulling();
                }
                currentSignalState = FishingRodSignalState.Pressed6;
                break;
            default:
                currentSignalState = FishingRodSignalState.None;
                break;
        }
    }
}

public enum FishingRodSignalState
{
    None,
    Pressed1,
    Pressed2,
    Pressed3,
    Pressed4,
    Pressed5,
    Pressed6
}




