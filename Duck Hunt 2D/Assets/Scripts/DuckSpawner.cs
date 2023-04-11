using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] GameObject[] duckPrefabs;
    [SerializeField] private float nextDuckTime;
    [SerializeField] private float duckDelay = 1.5f;
    [Header("Vectores")]
    [SerializeField] private float xMinTransform;
    [SerializeField] private float xMaxTransform;
    [SerializeField] private float yMinTransform;
    [SerializeField] private float yMaxTransform;

    private void Update()
    {
        if (Time.time >= nextDuckTime)
        {
            DuckSpawn();
            nextDuckTime = Time.time + duckDelay;
        }
    }

    public void DuckSpawn()
    {
        int randomDuck = Random.Range(0, duckPrefabs.Length);

        float xRandomPosition = Random.Range(xMinTransform, xMaxTransform);
        float yRandomPosition = Random.Range(yMinTransform, yMaxTransform);
        var position = new Vector3(xRandomPosition, yRandomPosition);

        GameObject newDuck = Instantiate(duckPrefabs[randomDuck], position, Quaternion.identity);
    }

}//Class

