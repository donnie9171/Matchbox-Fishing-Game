using System;
using UnityEngine;
using UnityEngine.Rendering;

public class CanvasManager : MonoBehaviour
{
    public GameObject canvasPrefab;
    public GameObject canvasPrefab2;
    public GameObject canvasPrefab3;


    public void Init()
    {
        canvasPrefab.SetActive(false);
        canvasPrefab2.SetActive(false);
        canvasPrefab3.SetActive(false);
    }

    public void GameOver()
    {
        ActivateCanvas(2);
    }

    public void StartFight()
    {
        ActivateCanvas(1);
    }

    public void ResetGame()
    {
        ActivateCanvas(0);
    }


    public void ActivateCanvas(int index)
    {
        if(index < 0 || index > 2)
        {
            Debug.LogError("Index out of range. Must be 0, 1, or 2.");
            return;
        }
        // Deactivate all canvases first
        canvasPrefab.SetActive(false);
        canvasPrefab2.SetActive(false);
        canvasPrefab3.SetActive(false);
        // Activate the selected canvas
        switch (index)
        {
            case 0:
                canvasPrefab.SetActive(true);
                break;
            case 1:
                canvasPrefab2.SetActive(true);
                break;
            case 2:
                canvasPrefab3.SetActive(true);
                break;
        }
    }
}
