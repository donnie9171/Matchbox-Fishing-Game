using UnityEngine;
using UnityEngine.UI;

public class FishSpriteController : MonoBehaviour
{
    public GameObject fishNormalSprite; // Normal fish sprite
    public GameObject fishAngrySprite;  // Angry fish sprite
    public GameObject fishFaintSprite;  // Happy fish sprite
    public Sprite[] fishCostumes;
    public Image baseImage; 


    public void SetNormalSprite()
    {
        fishNormalSprite.SetActive(true);
        fishAngrySprite.SetActive(false);
        fishFaintSprite.SetActive(false);
    }
    public void SetAngrySprite()
    {
        fishNormalSprite.SetActive(false);
        fishAngrySprite.SetActive(true);
        fishFaintSprite.SetActive(false);
    }
    public void SetFaintSprite()
    {
        fishNormalSprite.SetActive(false);
        fishAngrySprite.SetActive(false);
        fishFaintSprite.SetActive(true);
    }   

    public void SetFishCostume(int fish) {
        baseImage.sprite = fishCostumes[fish];
    }
}
