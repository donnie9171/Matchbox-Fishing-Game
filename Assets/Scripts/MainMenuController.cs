using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private string targetScene = "zoe's scene";
    
    public void PlayGame()
    {
        SceneTransitionManager.Instance.TransitionTo(targetScene);
    }
}
