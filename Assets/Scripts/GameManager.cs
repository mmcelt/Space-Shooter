using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	#region Fields

	public static GameManager Instance;

	public int _currentLives = 3;
	public int _currentScore;
	public bool _levelEnding;

	[SerializeField] float _respawnTime = 2f, _waitToLoadNextLevel=2.5f;
	[SerializeField] string _nextLevel;

	int _highScore, _levelScore;
	bool _canPause;

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
		_currentLives = PlayerPrefs.GetInt("CurrentLives");
		UIManager.Instance._livesText.text = "X " + _currentLives;

		_highScore = PlayerPrefs.GetInt("HighScore");
		UIManager.Instance._highScoreText.text = "Hi-Score: " + _highScore;

		_currentScore = PlayerPrefs.GetInt("CurrentScore");
		UIManager.Instance._scoreText.text = "Score: " + _currentScore;

		_canPause = true;
	}

	void Update()
	{
		if (_levelEnding)
		{
			PlayerController.Instance.transform.position += new Vector3(PlayerController.Instance._boostSpeed * Time.deltaTime, 0f, 0f);
		}

		if (Input.GetKeyDown(KeyCode.Escape) && _canPause)
			PauseUnpause();
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
			PlayerPrefs.SetInt("HighScore", _highScore);
			ClearAllVisibleEnemies();

			_canPause = false;
		}
	}

	public void UpdateScore(int amount)
	{
		_currentScore += amount;
		_levelScore += amount;

		UIManager.Instance._scoreText.text = "Score: " + _currentScore;
		if (_currentScore > _highScore)
		{
			_highScore = _currentScore;
			UIManager.Instance._highScoreText.text = "Hi-Score: " + _highScore;
			//PlayerPrefs.SetInt("HighScore", _highScore);
		}
	}

	public IEnumerator EndLevelRoutine()
	{
		UIManager.Instance._levelEndScreen.SetActive(true);
		PlayerController.Instance._stopMovement = true;
		_levelEnding = true;
		MusicController.Instance.PlayVictoryMusic();
		_canPause = false;

		yield return new WaitForSeconds(0.5f);

		UIManager.Instance._levelScoreText.text = "Level Score: " + _levelScore;
		UIManager.Instance._levelScoreText.gameObject.SetActive(true);

		yield return new WaitForSeconds(0.5f);

		PlayerPrefs.SetInt("CurrentScore", _currentScore);
		UIManager.Instance._totalScoreText.text = "Total Score: " + _currentScore;
		UIManager.Instance._totalScoreText.gameObject.SetActive(true);

		if (_currentScore > _highScore)
		{
			yield return new WaitForSeconds(0.5f);
			UIManager.Instance._highScoreNotice.SetActive(true);
		}

		PlayerPrefs.SetInt("HighScore", _highScore);
		PlayerPrefs.SetInt("CurrentLives", _currentLives);

		yield return new WaitForSeconds(_waitToLoadNextLevel);

		SceneManager.LoadScene(_nextLevel);
	}

	public void PauseUnpause()
	{
		if (UIManager.Instance._pauseScreen.activeInHierarchy)
		{
			UIManager.Instance._pauseScreen.SetActive(false);
			Time.timeScale = 1f;
			PlayerController.Instance._stopMovement = false;
		}
		else
		{
			UIManager.Instance._pauseScreen.SetActive(true);
			Time.timeScale = 0f;
			PlayerController.Instance._stopMovement = true;
		}
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
