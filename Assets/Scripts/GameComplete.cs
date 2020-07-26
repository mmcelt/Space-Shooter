using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameComplete : MonoBehaviour
{
	#region Fields

	[SerializeField] float _timeBetweenTexts;
	[SerializeField] string _mainMenuName = "MainMenu";
	[SerializeField] TextMeshProUGUI _messageText, _scoreText, _anyKeyText;

	bool _canExit;

	#endregion

	#region MonoBehaviour Methods

	void Start() 
	{
		StartCoroutine(ShowTextsRoutine());
	}
	
	void Update() 
	{
		if (_canExit && Input.anyKeyDown)
			SceneManager.LoadScene(_mainMenuName);
	}
	#endregion

	#region Public Methods

	#endregion

	#region Private Methods

	IEnumerator ShowTextsRoutine()
	{
		yield return new WaitForSeconds(_timeBetweenTexts);
		_messageText.gameObject.SetActive(true);

		yield return new WaitForSeconds(_timeBetweenTexts);
		_scoreText.text = "Final Score: " + PlayerPrefs.GetInt("CurrentScore");
		_scoreText.gameObject.SetActive(true);

		yield return new WaitForSeconds(_timeBetweenTexts);
		_anyKeyText.gameObject.SetActive(true);
		_canExit = true;
	}
	#endregion
}
