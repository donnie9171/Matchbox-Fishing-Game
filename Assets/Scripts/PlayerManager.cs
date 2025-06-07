using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int maxlifeCount = 3; // ��l�ͩR�ƶq
    public bool isGameOver; // �C���O�_����
    public bool isFightingWithFish = false; // �O�_���b�P���԰�

    public GameObject canvasManagerRef; // �Ѧ� CanvasManager\
    public GameObject playerhookRef;
    private CanvasManager canvasManager; // CanvasManager �����
    public SpriteSpawner spriteSpawner;
    private LifeCountList lifeCountList; // �Ω���ܥͩR�ƶq�� UI

    public GameObject fishfightManager;

    public int currentFishCount = 0; // ��e�����ƶq
    public int currentlifeCount = 3; 

    void Start()
    {
        canvasManager = canvasManagerRef.GetComponent<CanvasManager>(); // ��� CanvasManager �����
        canvasManager.Init(); // ��l�� CanvasManager
        canvasManager.ResetGame(); // �ҥΪ�l�e��
        isGameOver = false; // ��l�ƹC�����A

        currentlifeCount = maxlifeCount; // ��l�Ʒ�e�ͩR�ƶq
        lifeCountList = canvasManagerRef.GetComponentInChildren<LifeCountList>();
        lifeCountList.PopulateUIList(maxlifeCount); // �]�m�ͩR�ƶqUI
        lifeCountList.SetLifeCount(currentlifeCount, maxlifeCount); // ��l�ƥͩR�ƶqUI���

        fishfightManager.SetActive(false); // �T�O���԰��޲z����l�������ʪ��A

        spriteSpawner.StartSpawningObstacles(); // �}�l�ͦ���ê��
    }
    public void takedamage()
    {
        if (isGameOver) return; // �p�G�C���w�g�����A�h���B�z�ˮ`
        currentlifeCount--; // ��֥ͩR�ƶq
        lifeCountList.SetLifeCount(currentlifeCount, maxlifeCount);
        if (currentlifeCount <= 0)
        {
            currentlifeCount = 0;
            isGameOver = true; // �p�G�ͩR�ƶq�p�󵥩�0�A�h�C������
            Debug.Log("Game Over!");
            canvasManager.GameOver(); // �I�s CanvasManager �� GameOver ��k
            spriteSpawner.isGameOver = true; // ����ͦ���ê��
        }
    }

    public void OnFishFightEnter()
    {
        if (isFightingWithFish) return; // �p�G�w�g�b�P���԰��A�h���B�z
        spriteSpawner.PauseSpawning();
        playerhookRef.SetActive(false); // ���ó��_

        isFightingWithFish = true; // �]�m���b�P���԰������A
        canvasManager.StartFight(); // �I�s CanvasManager �� StartFight ��k
        fishfightManager.SetActive(true); // �ҥγ��԰��޲z��
    }

    public void OnFishFightExit()
    {
        if (!isFightingWithFish) return; // �p�G�S���b�P���԰��A�h���B�z
        if(currentlifeCount <= 0) return; // �p�G�ͩR�ƶq�p�󵥩�0�A�h���B�z
        spriteSpawner.ResumeSpawning();
        spriteSpawner.Respawnfish();

        fishfightManager.SetActive(false);
        playerhookRef.SetActive(true); // ��ܳ��_
        isFightingWithFish = false; // ���m���b�P���԰������A
        canvasManager.ResetGame(); // �I�s CanvasManager �� ResetGame ��k
    }

    public void CatchFish()
    {
        if (isGameOver) return; // �p�G�C���w�g�����A�h���B�z����
        currentFishCount++; // �W�[���򪺳��ƶq
        canvasManager.FishCatched(); // �I�s CanvasManager �� FishCatched ��k
        StartCoroutine(WaitAndExitFishFight());
    }

    public void FishGotAway()
    {
        if (isGameOver) return; // �p�G�C���w�g�����A�h���B�z���k��
        canvasManager.FishGotAway(); // �I�s CanvasManager �� FishGotAway ��k
        StartCoroutine(WaitAndExitFishFight());
    }

    private System.Collections.IEnumerator WaitAndExitFishFight()
    {
        yield return new WaitForSeconds(5f);
        OnFishFightExit();
    }
}
