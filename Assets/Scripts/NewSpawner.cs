using UnityEngine;

public class NewSpawner : MonoBehaviour {
    // Reference to the prefab to spawn
    public GameObject obstaclePrefab;

    // Public float to control the spawn rate (time in seconds between spawns)
    public float spawnRate = 2.0f;

    // Timer to keep track of time between spawns
    private float spawnTimer;

    // Start is called once before the first execution of Update
    void Start() {
        // Initialize the spawn timer to the spawn rate
        spawnTimer = spawnRate;
    }

    // Update is called once per frame
    void Update() {
        // Update the timer
        spawnTimer -= Time.deltaTime;

        // Check if it's time to spawn a new obstacle
        if (spawnTimer <= 0f) {
            // Spawn the obstacle at the current position
            SpawnObstacle();

            // Reset the spawn timer
            spawnTimer = spawnRate;
        }
    }

    // Method to spawn the obstacle
    void SpawnObstacle() {
        if (obstaclePrefab != null) {
            Instantiate(obstaclePrefab, transform.position, transform.rotation);
        } else {
            Debug.LogWarning("Obstacle prefab is not assigned!");
        }
    }
}