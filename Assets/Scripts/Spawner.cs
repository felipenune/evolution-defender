using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject target;

	private float spawnTime;
	public float startSpawnTime;

    void Start()
    {
		spawnTime = startSpawnTime;
    }

    void Update()
    {
		spawnTime -= Time.deltaTime;
		if (spawnTime <= 0)
		{
			spawnTime = startSpawnTime;
			Instantiate(target, transform.position, Quaternion.identity);
		}
    }
}
