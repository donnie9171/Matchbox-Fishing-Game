using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem; 
public class PlayerControl : MonoBehaviour
{
    [Header("Movement Parameter")]
    public float moveSpeed = 8f;

    [Header("Boundary Limit")]
    public float minX = -8f;
    public float maxX = 8f;
    public float minY = -4f;
    public float maxY = 4f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // called by Unity's physics system at fixed intervals
    public void Move(InputAction.CallbackContext context)
    {
        Debug.Log("Move called with context: " + context);

        // Fix for CS0019: Convert Axis to float and use it to scale Vector2.up
        float axisValue =context.ReadValue<float>();
        Vector2 direction = Vector2.up * axisValue;

        Vector2 newPosition = rb.position + direction * moveSpeed * Time.fixedDeltaTime;

        // Limit the player's position within the defined boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        // Fix for UNT0024: Reorder operands for better performance
        rb.MovePosition(newPosition);
    }
}
