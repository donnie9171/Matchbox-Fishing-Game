using TMPro;
using UnityEngine;

public class GradeOnCatch : MonoBehaviour
{
    public TextMeshProUGUI proUGUI;
    
    public void SetGrade(float grade)
    {
        if (proUGUI != null)
        {
            if(grade >= 30)
            {
                proUGUI.text = "F";
            }
            else if (grade >= 20)
            {
                proUGUI.text = "B";
            }
            else if (grade >= 10)
            {
                proUGUI.text = "A";
            }
            else
            {
                proUGUI.text = "S";
            }
        }
        else
        {
            Debug.LogWarning("proUGUI is not assigned in the inspector.");
        }
    }
}
