using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject zombiePrefabs;
    public float xBound = 6.5f, zBound = 7f;
    public float distanceZombie = 7f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnerZombieGameObject());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnerZombieGameObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            float randomDegress = Random.Range(0, Mathf.PI * 2);
            float randomX = Mathf.Sin(randomDegress) * distanceZombie;
            float randomZ = Mathf.Cos(randomDegress) * distanceZombie;

            GameObject newZombie = Instantiate(zombiePrefabs) as GameObject;
            newZombie.transform.position = new Vector3(randomX, 1, randomZ);
        }
    }
}
