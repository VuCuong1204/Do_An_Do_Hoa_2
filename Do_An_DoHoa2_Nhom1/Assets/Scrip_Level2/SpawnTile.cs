using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : MonoBehaviour
{
    public GameObject tileToSpawn;
    public GameObject referenceObject;
    public float timeOffset = 0.4f;
    public float distanceBetweenTiles = 5.0f;
    public float randomValue = 0.8f;
    private Vector3 previousTilePosition;
    private float startTime;
    private Vector3 direction, mainDirection = new Vector3(0, 0, 1), otherDirection = new Vector3(1, 0, 0);

    [SerializeField] GameObject coinPrefabs;
    [SerializeField] GameObject coinSpeedPrefabs;

    void Start()
    {
        previousTilePosition = referenceObject.transform.position;
        startTime = Time.time;

        SpawnCoins();
        SpawnCoinSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > timeOffset)
        {
            if (Random.value < randomValue)
                direction = mainDirection;
            else
            {
                Vector3 temp = direction;
                direction = otherDirection;
                mainDirection = direction;
                otherDirection = temp;
            }
            Vector3 spawnPos = previousTilePosition + distanceBetweenTiles * direction;
            startTime = Time.time;
            Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));
            previousTilePosition = spawnPos;
        }
    }

    Vector3 GetRandomCoin(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z));
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomCoin(collider);
        }
        point.y = 1;
        return point;
    }
    public void SpawnCoins()
    {
        int coinSpawn = 6;
        for (int i = 0; i < coinSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefabs, transform);
            temp.transform.position = GetRandomCoin(GetComponent<Collider>());
        }
    }
    public void SpawnCoinSpeed()
    {
        int coinSpeedSpawn = 2;
        for (int i = 0; i < coinSpeedSpawn; i++)
        {
            GameObject temp = Instantiate(coinSpeedPrefabs, transform);
            temp.transform.position = GetRandomCoin(GetComponent<Collider>());
        }
    }
}
