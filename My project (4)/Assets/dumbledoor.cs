using System.Collections;
using UnityEngine;

public class TumbleweedSpawner : MonoBehaviour
{
    public GameObject tumbleweedPrefab; 
    public float spawnInterval = 3f; 
    public int maxTumbleweeds = 5;
    public float tumbleweedSpeed = 2f; 
    public float tumbleweedRotationSpeed = 100f;
    public Vector2 spawnRangeY = new Vector2(-4f, 4f); 

    private int currentTumbleweeds = 0;

    void Start()
    {
        // Start the spawning process
        StartCoroutine(SpawnTumbleweeds());
    }

    IEnumerator SpawnTumbleweeds()
    {
        while (true)
        {
            if (currentTumbleweeds < maxTumbleweeds)
            {
                SpawnTumbleweed();
            }
            yield return new WaitForSeconds(spawnInterval); 
        }
    }

    void SpawnTumbleweed()
    {
        float spawnY = Random.Range(spawnRangeY.x, spawnRangeY.y);

        Vector3 spawnPosition = new Vector3(Camera.main.transform.position.x - 10f, spawnY, 0);

        GameObject tumbleweed = Instantiate(tumbleweedPrefab, spawnPosition, Quaternion.identity);

        Rigidbody2D rb = tumbleweed.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = new Vector2(tumbleweedSpeed, 0); 
        }

        currentTumbleweeds++;

        Destroy(tumbleweed, 10f);

        StartCoroutine(RollTumbleweed(tumbleweed));
    }

    IEnumerator RollTumbleweed(GameObject tumbleweed)
    {
        while (tumbleweed != null)
        {
            tumbleweed.transform.Rotate(Vector3.forward * tumbleweedRotationSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
