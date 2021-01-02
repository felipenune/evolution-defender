using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
	public GameObject bullet;
	public PlayerStats playerStats;
	public float timeBtwSpawns;
	private float spawnTime;

	private void Start()
	{
		spawnTime = timeBtwSpawns;
	}

	void Update()
    {
		spawnTime -= Time.deltaTime;

		if (Input.touchCount > 0 && playerStats.gameOver == false 
			|| Input.GetMouseButton(0) && playerStats.gameOver == false)
		{
			if (spawnTime <= 0)
			{
				Instantiate(bullet, transform.position, Quaternion.identity);
				spawnTime = timeBtwSpawns;
			}
			
		}
    }
}
