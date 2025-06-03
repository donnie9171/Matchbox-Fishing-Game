using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int maxlifeCount = 3; // ��l�ͩR�ƶq
    public bool isGameOver = false; // �C���O�_����
    public bool isFightingWithFish = false; // �O�_���b�P���԰�

    public GameObject canvasManagerRef; // �Ѧ� CanvasManager

    public int currentFishCount = 0; // ��e�����ƶq
    public int currentlifeCount = 3; 

    void Start()
    {
        currentlifeCount = maxlifeCount; // ��l�Ʒ�e�ͩR�ƶq
        LifeCountList lifeCountList = canvasManagerRef.GetComponentInChildren<LifeCountList>();
        lifeCountList.PopulateUIList(maxlifeCount); // �]�m�ͩR�ƶqUI
        lifeCountList.SetLifeCount(currentlifeCount, maxlifeCount); // ��l�ƥͩR�ƶqUI���
    }
    public void takedamage()
    {
        if (isGameOver) return; // �p�G�C���w�g�����A�h���B�z�ˮ`
        currentlifeCount--; // ��֥ͩR�ƶq
        if (currentlifeCount <= 0)
        {
            currentlifeCount = 0;
            isGameOver = true; // �p�G�ͩR�ƶq�p�󵥩�0�A�h�C������
            Debug.Log("Game Over!");
            canvasManagerRef.GetComponent<CanvasManager>().GameOver(); // �I�s CanvasManager �� GameOver ��k
        }
    }
}
