using UnityEngine;

public class ConnectTwoPoints : MonoBehaviour
{
    public Transform hookAttachmentPoint1; // First target point
    public Transform hookAttachmentPoint2; // Second target point

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (hookAttachmentPoint1 != null && hookAttachmentPoint2 != null && spriteRenderer != null)
        {
            // Get the Y positions of the two attachment points
            float y1 = hookAttachmentPoint1.position.y;
            float y2 = hookAttachmentPoint2.position.y;

            // Calculate the midpoint and height
            float midY = (y1 + y2) / 2f;
            float height = Mathf.Abs(y1 - y2);

            // Set the sprite's position to the midpoint
            Vector3 newPosition = transform.position;
            newPosition.y = midY;
            transform.position = newPosition;

            // Update the sprite renderer's size
            Vector2 newSize = spriteRenderer.size;
            newSize.y = height; // Update the height based on the distance
            spriteRenderer.size = newSize;
        }
    }
}