using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool adaptive;
    public GameObject[] elements;
    public float yMin, yMax;
    public float minTime, maxTime;
    public float adaptTime = 10f;

    private float spawnTime;
    private float lastSpawn;
    private List<GameObject> spawnedObjects;

    void Start()
    {
        this.spawnTime = Random.Range(minTime, maxTime);
        this.lastSpawn = 0f;
        this.spawnedObjects = new List<GameObject>();

        StartCoroutine(Adapt());
    }

    void Update()
    {
        if( Time.time - lastSpawn > this.spawnTime)
        {
            this.lastSpawn = Time.time;
            this.spawnTime = Random.Range(minTime, maxTime);

            GameObject go = (GameObject)Instantiate(elements[Random.Range(0, elements.Length)], 
                this.transform.position,
                Quaternion.identity);

            go.transform.SetParent(this.transform, true);
            go.transform.Translate(Vector3.up * Random.Range(-300f, 300f));
            //this.spawnedObjects.Add(go);
            //print(this.spawnedObjects.Count);
        }
    }

    private IEnumerator Adapt()
    {
        while(true)
        {
            yield return new WaitForSeconds(this.adaptTime);
            this.maxTime *= .85f;
            this.minTime *= .85f;
        }
    }

    public void Clear()
    {
        Move[] enemys = GetComponentsInChildren<Move>();
        for (int i = 0; i < enemys.Length; i++)
        {
            enemys[i].ClearEnemy();
        }
    }

    public void Bonus()
    {
        this.minTime += .5f;
        this.maxTime += .5f;
    }
}
