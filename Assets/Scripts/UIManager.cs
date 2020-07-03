using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	#region Fields

	public static UIManager Instance;

	public GameObject _gameOverScreen;
	public Text _livesText, _scoreText, _highScoreText;
	public Slider _healthbar;

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
	}

	public void OnMainMenuButtonClicked()
	{
		Debug.Log("Back to Main Menu...");
	}
	#endregion

	#region Private Methods


	#endregion
}
