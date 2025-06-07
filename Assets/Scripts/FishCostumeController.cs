using UnityEngine;

public class FishCostumeController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Sprite[] fishCostumes;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCostume(int costumeIndex) {
        if (costumeIndex < 0 || costumeIndex >= fishCostumes.Length) {
            Debug.LogError("Invalid costume index: " + costumeIndex);
            return;
        }
        spriteRenderer.sprite = fishCostumes[costumeIndex];
    }
}
