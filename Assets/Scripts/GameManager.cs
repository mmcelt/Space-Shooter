using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	#region Fields

	public static GameManager Instance;

	public int _currentLives = 3;

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
	#endregion

	#region Public Methods

	public void KillPlayer()
	{
		_currentLives--;
		_currentLives = Mathf.Max(0, _currentLives);

		if (_currentLives > 0)
		{
			//respawn code...
			StartCoroutine(RespawnRoutine());
		}
		else
		{
			//game over code...

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
	#endregion
}
