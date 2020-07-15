using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	#region Fields

	public static UIManager Instance;

	public GameObject _gameOverScreen, _levelEndScreen, _highScoreNotice, _pauseScreen;
	public Text _livesText, _scoreText, _highScoreText;
	public Slider _healthbar, _shieldbar;
	public TextMeshProUGUI _levelScoreText, _totalScoreText;
	[SerializeField] string _mainMenuScene;

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
		
	}
	#endregion

	#region Public Methods

	public void OnRestartButtonClicked()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		Time.timeScale = 1f;
	}

	public void OnMainMenuButtonClicked()
	{
		Debug.Log("Back to Main Menu...");
		Time.timeScale = 1f;
	}

	public void OnResumeButtonClicked()
	{
		GameManager.Instance.PauseUnpause();
	}
	#endregion

	#region Private Methods


	#endregion
}
