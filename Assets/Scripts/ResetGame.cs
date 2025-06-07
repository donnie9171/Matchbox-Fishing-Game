using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{

    // 重新啟動當前場景的方法
    public void RestartActiveScene()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
    }
}
