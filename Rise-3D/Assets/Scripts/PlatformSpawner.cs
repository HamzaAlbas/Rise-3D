using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;

    private void Start()
    {
        StartCoroutine(CubeSpawnCoroutine());
    }

    IEnumerator CubeSpawnCoroutine()
    {
        while (true)
        {
            SpawnCube();
            yield return new WaitForSeconds(3f);
        }
    }

    public void SpawnCube()
    {
        Vector3 position = new Vector3(Random.Range(-2f, 2f), -10, 0);
        Instantiate(platformPrefab, position, Quaternion.identity, gameObject.transform);   
    }
}
