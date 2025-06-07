using UnityEngine;

public class ReloadScene : MonoBehaviour
{
    public void ReloadCurrentScene()
    {
        // Get the current scene
        var currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        
        // Reload the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene.name);
    }
}
