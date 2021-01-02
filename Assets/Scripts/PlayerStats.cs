using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
	[Header("Stats")]
	public int points;

	[Space]
	[Header("Power Up")]
	public float startPowerTime;
	private float powerTime;

	[Space]
	[Header("References")]
	public LevelController levelController;
	public GameManager gameManager;
	public ParticleSystem deathParticles;
	private SpriteRenderer sprite;

	[Space]
	[Header("Booleans")]
	public bool gameOver = false;
	public bool powered = false;

	void Start()
	{
		sprite = GetComponentInChildren<SpriteRenderer>();
		powerTime = startPowerTime;
	}

	void Update()
    {
		if (points >= levelController.level * 50)
		{
			levelController.level += 1;
		}

		if (gameOver && sprite.enabled == true)
		{
			StartCoroutine(EndGame());
		}

		if (powered)
		{
			powerTime -= Time.deltaTime;
		}

		if (powerTime <= 0)
		{
			powered = false;
			powerTime = startPowerTime;
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("target"))
		{			
			gameOver = true;		
		}

		if (collision.CompareTag("power"))
		{
			powered = true;
			Destroy(collision.gameObject);
		}
	}

	IEnumerator EndGame()
	{
		Instantiate(deathParticles, transform.position, Quaternion.identity);
		sprite.enabled = false;
		yield return new WaitForSeconds(1);
		gameManager.GameOver();
	}
}
