using UnityEngine;

public class SpriteSinoMovement : MonoBehaviour
{
    public float amplitude = 1f;    // 波動幅度（上下移動的高度）
    public float frequency = 1f;    // 波動頻率（速度）

    private Vector3 startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
