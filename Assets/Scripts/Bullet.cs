using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed;
	private int damage;
	private Target target;
	private PlayerStats playerStats;
	private SpriteRenderer sprite;

	void Start()
    {
		GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
		playerStats = FindObjectOfType<PlayerStats>();
		sprite = GetComponent<SpriteRenderer>();

		if (playerStats.powered)
		{
			damage = 20;
			sprite.color = Color.red;
		}

		else
		{
			damage = 5;
			sprite.color = Color.white;
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		SpriteRenderer otherSprite = other.collider.GetComponent<SpriteRenderer>();

		if (other.collider.CompareTag("target") && otherSprite.isVisible)
		{
			target = other.collider.GetComponent<Target>();
			target.life -= damage;
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("limits"))
		{
			Destroy(gameObject);
		}
	}
}
