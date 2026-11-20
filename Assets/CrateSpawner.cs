using UnityEngine;

public class CrateSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cratePrefab;
    [SerializeField] private float interval = 2f;
    [SerializeField] private float minX = -4f;
    [SerializeField] private float maxX = 4f;
    [SerializeField] private float lifetime = 10f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f;
            Spawn();
        }
    }

    void Spawn()
    {
        float x = Random.Range(minX, maxX);
        Vector3 position = new Vector3(x, transform.position.y, 0f);

        GameObject crate = Instantiate(cratePrefab, position, Quaternion.identity);
        Destroy(crate, lifetime);
    }
}