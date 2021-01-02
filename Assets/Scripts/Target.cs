using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
	[Header("Movement")]
	private float waitTime;
	public float startWaitTime;

	[Space]
	[Header("Stats")]
	public int life;
	private int actualLevel;

	[Space]
	[Header("Power Ups")]
	private int randomPowerUp;
	public GameObject[] powerUp;

	[Space]
	[Header("References")]
	public LevelController levelController;
	private SpriteRenderer sprite;
	public TextMesh textLife;	
	public PlayerStats playerPoints;

	[Space]
	[Header("Particles")]
	public ParticleSystem[] particles;

	[Space]
	[Header("Colors")]
	public Color[] colorLvl;
	
	void Start()
    {
		waitTime = startWaitTime;
		sprite = GetComponent<SpriteRenderer>();
		levelController = FindObjectOfType<LevelController>();
		playerPoints = FindObjectOfType<PlayerStats>();
		life = levelController.level * 10;
		actualLevel = levelController.level;
		randomPowerUp = Random.Range(0,100);

		Colors();
    }

    void Update()
    {
		waitTime -= Time.deltaTime;

		if (waitTime <= 0)
		{
			waitTime = startWaitTime;
			transform.position = new Vector2(transform.position.x, transform.position.y - 0.8f);
		}

		textLife.text = life.ToString();

		if (life <= 0)
		{
			Instantiate(particles[actualLevel - 1],transform.position,Quaternion.identity);
			playerPoints.points += 1;
			PowerUps();
			Destroy(gameObject);
		}
    }

	void Colors()
	{
		sprite.color = colorLvl[levelController.level - 1];
		textLife.color = colorLvl[levelController.level - 1];
	}

	void PowerUps()
	{
		if (randomPowerUp != 0)
		{
			return;
		}

		else
		{
			Instantiate(powerUp[randomPowerUp], transform.position, Quaternion.identity);
		}		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("destroyer"))
		{
			Destroy(gameObject);
		}
	}
}
