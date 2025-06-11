using TMPro;
using UnityEngine;

public class DepthUIVisual : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    
    public void UpdateDepth(float depth)
    {
        if (textMeshProUGUI != null)
        {
            textMeshProUGUI.text = "Depth: " + depth.ToString("F2") + " m"; // Format the depth to 2 decimal places
        }
    }
}
