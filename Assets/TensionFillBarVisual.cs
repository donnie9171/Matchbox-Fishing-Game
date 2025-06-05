using UnityEngine;
using UnityEngine.UI; // �ޤJ UI �R�W�Ŷ�
public class TensionFillBarVisual : MonoBehaviour
{
    public Slider tensionSlider; // �Ѧ� Slider �ե�A�Ω���ܱi�O��
    public FishfightGameManager fishfightGameManager;
    public Image fillImage; // �ѦҶ�R�Ϲ��A�Ω����C��


    // Update is called once per frame
    void Update()
    {
        float tension = fishfightGameManager.currentTension / 100f;
        tensionSlider.value = tension; // ��s�i�O������R���
        fillImage.color = Color.Lerp(Color.green, Color.red, tension); // �ھڱi�O�ܤ��C��
    }
}
