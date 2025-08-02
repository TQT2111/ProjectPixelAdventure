using System.Collections.Generic;
using UnityEngine;

public class FruitsSpawner : MonoBehaviour
{
    [SerializeField] private float timer = 0f;
    [SerializeField] private float spawnDelay = 1f;
    [SerializeField] private GameObject fruits;
    [SerializeField] private List<GameObject> fruitsPrefabs;
    [SerializeField] private List<Transform> fruitsSpawnPos;
    private List<GameObject> fruitPool = new List<GameObject>();
    private void Start()
    {
        fruits = GameObject.Find("Fruits");
        fruits.SetActive(false);
        InitializePool(10);
    }
    void Update()
    {
        SpawnTimer();
    }
    private void InitializePool(int poolSize)
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject fruit = CreateNewFruit();
            fruit.SetActive(false);
            fruitPool.Add(fruit);
        }
    }

    private GameObject CreateNewFruit()
    {
        if (fruitsPrefabs.Count == 0)
        {
            Debug.LogWarning("Fruits prefabs list is empty!");
            return null;
        }

        GameObject randomFruit = fruitsPrefabs[Random.Range(0, fruitsPrefabs.Count)];
        return Instantiate(randomFruit, Vector3.zero, Quaternion.identity);
    }

    private void SpawnTimer()
    {
        timer += Time.deltaTime;

        if (timer >= spawnDelay)
        {
            SpawnFruit();
            timer = 0f;
        }
    }

    private void SpawnFruit()
    {
        if (fruitsPrefabs.Count == 0 || fruitsSpawnPos.Count == 0)
        {
            Debug.LogWarning("Fruits prefabs or spawn positions list is empty!");
            return;
        }

        GameObject fruitToSpawn = GetPooledFruit();

        if (fruitToSpawn == null)
        {
            fruitToSpawn = CreateNewFruit();
            if (fruitToSpawn != null)
            {
                fruitPool.Add(fruitToSpawn);
            }
        }

        if (fruitToSpawn != null)
        {
            Transform randomPos = GetRandom();
            fruitToSpawn.transform.position = randomPos.position;
            fruitToSpawn.transform.rotation = randomPos.rotation;
            fruitToSpawn.SetActive(true);
        }
    }

    private GameObject GetPooledFruit()
    {
        foreach (GameObject fruit in fruitPool)
        {
            if (!fruit.activeInHierarchy)
            {
                return fruit;
            }
        }
        return null;
    }

    public virtual Transform GetRandom()
    {
        if (fruitsSpawnPos.Count == 0)
        {
            Debug.LogWarning("No spawn positions assigned!");
            return transform;
        }

        int rand = Random.Range(0, fruitsSpawnPos.Count);
        return fruitsSpawnPos[rand];
    }

    public void DespawnFruit(GameObject fruit)
    {
        fruit.SetActive(false);
    }
}
