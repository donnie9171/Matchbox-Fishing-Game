using UnityEngine;
using UnityEngine.UI;

public class TimingBarController : MonoBehaviour
{
    public RectTransform barArea;       // The RectTransform of the bar background
    public RectTransform movingPoint;   // The RectTransform of the moving point
    public float speed = 2f;
    public AnimationCurve curve;// Speed of the moving point

    private float barWidth;
    private float halfBarWidth;
    private bool movingRight = true;
    private bool stopped = false;

    void Start()
    {
        barWidth = barArea.rect.width;
        halfBarWidth = barWidth * 0.5f;
        ResetPoint();
    }

    void Update()
    {
        if (!stopped)
        {
            float move = speed * Time.deltaTime * (movingRight ? 1 : -1);
            movingPoint.anchoredPosition += new Vector2(move, 0);

            // Check bounds
            if (movingPoint.anchoredPosition.x > halfBarWidth)
            {
                movingPoint.anchoredPosition = new Vector2(halfBarWidth, 0);
                movingRight = false;
            }
            else if (movingPoint.anchoredPosition.x < -halfBarWidth)
            {
                movingPoint.anchoredPosition = new Vector2(-halfBarWidth, 0);
                movingRight = true;
            }

            // Stop on click
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                stopped = true;
                CheckSuccess();
                ResetPoint();
            }
        }
        else
        {
            // Reset if needed (optional)
            if (Input.GetKeyDown(KeyCode.R))
            {
                ResetPoint();
            }
        }
    }

    void ResetPoint()
    {
        movingPoint.anchoredPosition = new Vector2(-halfBarWidth, 0);
        movingRight = true;
        stopped = false;
    }

    void CheckSuccess()
    {
        // You can define your 'success area' here (e.g., within 10 units of center)
        float distance = Mathf.Abs(movingPoint.anchoredPosition.x);
        Debug.Log("Distance from center: " + distance);

        if (distance < 400f) // <--- Adjust as needed
        {
            Debug.Log("Great timing!");
        }
        else
        {
            Debug.Log("Try again!");
        }
    }
}
