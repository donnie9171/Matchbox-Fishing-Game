using UnityEngine;
using UnityEngine.UI;

public class TipsVisual : MonoBehaviour
{
    public Image image;
    public Sprite[] sprites;

    public void IsFainted(bool isFainted)
    {
        if(isFainted)
        {
            image.sprite = sprites[0]; // Set to fainted sprite
        }
        else
        {
            image.sprite = sprites[1]; // Set to normal sprite
        }
    }
}
