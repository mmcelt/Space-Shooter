using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	#region Fields

	[SerializeField] string _firstLevel;

	#endregion

	#region MonoBehaviour Methods

	#endregion

	#region Public Methods

	public void OnStartGameButtonClicked()
	{
		PlayerPrefs.SetInt("CurrentLives", 3);
		PlayerPrefs.SetInt("CurrentScore", 0);

		SceneManager.LoadScene(_firstLevel);
	}

	public void OnQuitGameButtonClicked()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
		Application.Quit();
	}
	#endregion

	#region Private Methods


	#endregion
}
