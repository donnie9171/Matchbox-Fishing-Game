using UnityEngine;

public class OceanScrolling : MonoBehaviour
{
    public float scrollSpeed = 2f; 
    public Transform sprite1;      
    public Transform sprite2;
    public Transform sprite3;
    public Transform sprite4;

    private float spriteWidth;     

    void Start()
    {
        if (sprite1 == null || sprite2 == null)
        {
            Debug.LogError("請在 Inspector 指定 sprite1 和 sprite2。");
            enabled = false;
            return;
        }

        
        spriteWidth = sprite1.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        
        sprite1.position += Vector3.left * scrollSpeed * Time.deltaTime;
        sprite2.position += Vector3.left * scrollSpeed * Time.deltaTime;
        sprite3.position += Vector3.left * 2 * scrollSpeed * Time.deltaTime;
        sprite4.position += Vector3.left * 2 * scrollSpeed * Time.deltaTime;


        if (sprite1.position.x <= -spriteWidth)
        {
            sprite1.position = new Vector3(sprite2.position.x + spriteWidth, sprite1.position.y, sprite1.position.z);
        }
        if (sprite2.position.x <= -spriteWidth)
        {
            sprite2.position = new Vector3(sprite1.position.x + spriteWidth, sprite2.position.y, sprite2.position.z);
        }
        if (sprite3.position.x <= -spriteWidth)
        {
            sprite3.position = new Vector3(sprite4.position.x + spriteWidth, sprite3.position.y, sprite3.position.z);
        }
        if (sprite4.position.x <= -spriteWidth)
        {
            sprite4.position = new Vector3(sprite3.position.x + spriteWidth, sprite4.position.y, sprite4.position.z);
        }
    }
}
