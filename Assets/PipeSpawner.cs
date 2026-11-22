using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float pipeSpeed = 5f;
    [SerializeField] private float spawnX = 20f;
    [SerializeField] private float minY = -4f;
    [SerializeField] private float maxY = 4f;
    [SerializeField] private float screenLeftEdge = -20f;

    private float spawnTimer = 0f;

    private void Start()
    {
        transform.position = new Vector3(20f, 0f, 0f);
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnPipe();
            spawnTimer = 0f;
        } 
    }

    private void SpawnPipe()
    {
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(spawnX, randomY, 0f);
        GameObject pipe = Instantiate(pipePrefab, spawnPos, Quaternion.identity);

        // Y pozisyonunu force set et
        pipe.transform.position = spawnPos;

        Rigidbody2D rb = pipe.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(-pipeSpeed, 0f);
            Debug.Log($"Rigidbody velocity set to: {rb.linearVelocity}");
        }

        // Pipes ekranda daha uzun kalacak şekilde destroy time'ını ayarla
        float distanceToDestroy = spawnX - screenLeftEdge;
        float destroyTime = distanceToDestroy / pipeSpeed;
Destroy(pipe, destroyTime);
    }
}
