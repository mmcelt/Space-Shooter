using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	#region Fields

	public static GameManager Instance;

	public int _currentLives = 3;
	public int _currentScore;

	[SerializeField] float _respawnTime = 2f;

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
			ClearAllVisibleEnemies();
		}
	}

	public void UpdateScore(int amount)
	{
		_currentScore += amount;
		UIManager.Instance._scoreText.text = "Score: " + _currentScore;
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
