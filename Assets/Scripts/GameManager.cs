using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public GameObject gameOver;
	public GameObject pointsText;
	public GameObject levelText;
	public PlayerStats playerStats;

	private void Start()
	{
		gameOver.SetActive(false);
		Time.timeScale = 1f;
	}

	void Update()
	{
		pointsText.GetComponent<Text>().text = playerStats.points.ToString();
		levelText.GetComponent<Text>().text = ("Level " + playerStats.levelController.level.ToString());
	}

	public void GameOver()
	{
		Time.timeScale = 0f;
		gameOver.SetActive(true);
	}

	public void Retry()
	{
		SceneManager.LoadScene(0);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
