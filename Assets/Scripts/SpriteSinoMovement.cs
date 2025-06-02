using UnityEngine;

public class SpriteSinoMovement : MonoBehaviour
{
    public float amplitude = 1f;    // �i�ʴT�ס]�W�U���ʪ����ס^
    public float frequency = 1f;    // �i���W�v�]�t�ס^

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
