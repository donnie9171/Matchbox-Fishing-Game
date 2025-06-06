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
            Debug.Log("Pressed 2");
            SwitchStateForInput(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Pressed 3");
            SwitchStateForInput(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("Pressed 5");
            SwitchStateForInput(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Debug.Log("Pressed 7");
            SwitchStateForInput(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Debug.Log("Pressed 8");
            SwitchStateForInput(8);
        }
    }
    private void SwitchStateForInput(int inputNumber)
    {

        switch (inputNumber)
        {
            case 2:
                if(currentSignalState == FishingRodSignalState.Pressed2)
                {
                    
                    return; // Ignore if already in Pressed2 state
                }
                if(currentSignalState == FishingRodSignalState.Pressed3)
                {
                    playerControl.Move(-1);
                } else if (currentSignalState == FishingRodSignalState.Pressed8)
                {
                    playerControl.Move(1);
                    Debug.Log("Pressed 2, currentSignalState: "+ fishPullingFunction.IsFainted().ToString());
                    if (fishPullingFunction.IsFainted()) fishPullingFunction.FishPulling();
                }
                currentSignalState = FishingRodSignalState.Pressed2;
                break;
            case 3:
                if (currentSignalState == FishingRodSignalState.Pressed3)
                {

                    return; // Ignore if already in Pressed2 state
                }
                if (currentSignalState == FishingRodSignalState.Pressed5)
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
            case 5:
                if (currentSignalState == FishingRodSignalState.Pressed5)
                {

                    return; // Ignore if already in Pressed2 state
                }
                if (currentSignalState == FishingRodSignalState.Pressed7)
                {
                    playerControl.Move(-1);
                }
                else if (currentSignalState == FishingRodSignalState.Pressed3)
                {
                    playerControl.Move(1);
                    if (fishPullingFunction.IsFainted()) fishPullingFunction.FishPulling();
                }
                currentSignalState = FishingRodSignalState.Pressed5;
                break;
            case 7:
                if (currentSignalState == FishingRodSignalState.Pressed7)
                {

                    return; // Ignore if already in Pressed2 state
                }
                if (currentSignalState == FishingRodSignalState.Pressed8)
                {
                    playerControl.Move(-1);
                }
                else if (currentSignalState == FishingRodSignalState.Pressed5)
                {
                    playerControl.Move(1);
                    if (fishPullingFunction.IsFainted()) fishPullingFunction.FishPulling();
                }
                currentSignalState = FishingRodSignalState.Pressed7;
                break;
            case 8:
                if (currentSignalState == FishingRodSignalState.Pressed8)
                {

                    return; // Ignore if already in Pressed2 state
                }
                if (currentSignalState == FishingRodSignalState.Pressed2)
                {
                    playerControl.Move(-1);
                }
                else if (currentSignalState == FishingRodSignalState.Pressed7)
                {
                    playerControl.Move(1);
                    if (fishPullingFunction.IsFainted()) fishPullingFunction.FishPulling();
                }
                currentSignalState = FishingRodSignalState.Pressed8;
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
    Pressed2,
    Pressed3,
    Pressed5,
    Pressed7,
    Pressed8
}




