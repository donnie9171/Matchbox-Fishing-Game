using UnityEngine;

public class FishManagerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int currentFish;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int NewFish() {
        currentFish = Random.Range(0, 5);
        return currentFish;
    }

    public int GetCurrentFish() {
        return currentFish;
    }

}
