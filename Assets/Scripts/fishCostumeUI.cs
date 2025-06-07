using UnityEngine;
using UnityEngine.UI;

public class fishCostumeUI : MonoBehaviour
{
    public Sprite[] fishCostumes;
    public Image baseImage;

    public void SetFishCostume(int fish)
    {
        baseImage.sprite = fishCostumes[fish];
    }
}
