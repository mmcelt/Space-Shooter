using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
	#region Fields

	public static MusicController Instance;

	[SerializeField] AudioSource _levelMusic, _bossMusic, _victoryMusic, _gameOverMusic;

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
		_levelMusic.Play();
	}
	#endregion

	#region Public Methods

	public void StopAllMusic()
	{
		_levelMusic.Stop();
		_bossMusic.Stop();
		_victoryMusic.Stop();
		_gameOverMusic.Stop();
	}

	public void PlayBossMusic()
	{
		StopAllMusic();
		_bossMusic.Play();
	}

	public void PlayVictoryMusic()
	{
		StopAllMusic();
		_victoryMusic.Play();
	}

	public void PlayGameOverMusic()
	{
		StopAllMusic();
		_gameOverMusic.Play();
	}
	#endregion

	#region Private Methods


	#endregion
}
