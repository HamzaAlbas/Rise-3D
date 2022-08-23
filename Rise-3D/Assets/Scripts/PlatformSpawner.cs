using System.Collections;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public float timeBetweenWaves = 1f;
    private float timeToSpawn = 2f;
    [SerializeField] private GameObject platformPrefab;
    public RectTransform[] objects;


    private void Update()
    {
        if (PlayerController.Instance.isGameStarted)
        {
            if (Time.time >= timeToSpawn)
            {
                SpawnCube();
                timeToSpawn = Time.time + timeBetweenWaves;
            }
        } 
    }


    public void SpawnCube()
    {
        int randomSelector = Random.Range(0, objects.Length);

        for (int i = 0; i < objects.Length; i++)
        {
            if (randomSelector != i)
            {
                Vector3 spawnPos = Camera.main.ViewportToWorldPoint(objects[i].position);
                Vector3 lastPos = Camera.main.WorldToViewportPoint(spawnPos);

                Instantiate(platformPrefab, new Vector3(lastPos.x, lastPos.y + 1.5f, 0), Quaternion.identity);
            }
        }
    }
}
