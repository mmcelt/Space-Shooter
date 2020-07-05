﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	#region Fields

	public static GameManager Instance;

	public int _currentLives = 3;
	public int _currentScore;
	public bool _levelEnding;

	[SerializeField] float _respawnTime = 2f;

	int _highScore;

	#endregion

	#region MonoBehaviour Methods

	void Awake()
	{
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy(gameObject);
	}

	void Start()
	{
		UIManager.Instance._scoreText.text = "Score: " + _currentScore;
		//_highScore = PlayerPrefs.GetInt("HighScore");
		//UIManager.Instance._highScoreText.text = "Hi-Score: " + _highScore;
		UIManager.Instance._highScoreText.text = "Hi-Score: " + PlayerPrefs.GetInt("HighScore");
	}

	void Update()
	{
		if (_levelEnding)
		{
			PlayerController.Instance.transform.position += new Vector3(PlayerController.Instance._boostSpeed * Time.deltaTime, 0f, 0f);
		}
	}
	#endregion

	#region Public Methods

	public void KillPlayer()
	{
		_currentLives--;
		_currentLives = Mathf.Max(0, _currentLives);
		UIManager.Instance._livesText.text = "X " + _currentLives;

		if (_currentLives > 0)
		{
			//respawn code...
			StartCoroutine(RespawnRoutine());
		}
		else
		{
			//game over code...
			UIManager.Instance._gameOverScreen.SetActive(true);
			WaveManager.Instance._canSpawnWaves = false;
			MusicController.Instance.PlayGameOverMusic();
			ClearAllVisibleEnemies();
		}
	}

	public void UpdateScore(int amount)
	{
		_currentScore += amount;
		UIManager.Instance._scoreText.text = "Score: " + _currentScore;
		if (_currentScore > _highScore)
		{
			_highScore = _currentScore;
			UIManager.Instance._highScoreText.text = "Hi-Score: " + _highScore;
			PlayerPrefs.SetInt("HighScore", _highScore);
		}
	}

	public IEnumerator EndLevelRoutine()
	{
		UIManager.Instance._levelEndScreen.SetActive(true);
		PlayerController.Instance._stopMovement = true;
		_levelEnding = true;
		MusicController.Instance.PlayVictoryMusic();

		yield return new WaitForSeconds(0.5f);
	}
	#endregion

	#region Private Methods

	IEnumerator RespawnRoutine()
	{
		yield return new WaitForSeconds(_respawnTime);
		//respawn player...
		HealthManager.Instance.RespawnPlayer();
		WaveManager.Instance.ContinueSpawning();
	}
	void ClearAllVisibleEnemies()
	{
		GameObject[] visibleEnemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject enemy in visibleEnemies)
			enemy.SetActive(false);
	}
	#endregion
}
