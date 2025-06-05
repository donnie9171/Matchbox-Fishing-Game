using UnityEngine;
using UnityEngine.UI; // 引入 UI 命名空間
public class TensionFillBarVisual : MonoBehaviour
{
    public Slider tensionSlider; // 參考 Slider 組件，用於顯示張力條
    public FishfightGameManager fishfightGameManager;
    public Image fillImage; // 參考填充圖像，用於更改顏色


    // Update is called once per frame
    void Update()
    {
        float tension = fishfightGameManager.currentTension / 100f;
        tensionSlider.value = tension; // 更新張力條的填充比例
        fillImage.color = Color.Lerp(Color.green, Color.red, tension); // 根據張力變化顏色
    }
}
