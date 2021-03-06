﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
	#region Fields

	public static WaveManager Instance;

	[SerializeField] WaveObject[] _waves;

	public int _currentWave;
	public float _timeToNextWave;

	public bool _canSpawnWaves;

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
		if(_waves.Length > 0)
		{
			_timeToNextWave = _waves[_currentWave]._timeToSpawn;
			_canSpawnWaves = true;
		}
	}

	void Update()
	{
		if (_canSpawnWaves)
		{
			_timeToNextWave -= Time.deltaTime;
			if (_timeToNextWave <= 0)
			{
				Instantiate(_waves[_currentWave]._theWave, transform.position, Quaternion.identity);

				if (_currentWave < _waves.Length - 1)
				{
					_currentWave++;
					_timeToNextWave = _waves[_currentWave]._timeToSpawn;
				}
				else
				{
					//end of level?
					_canSpawnWaves = false;
					Debug.Log("Out of Waves!");
					StartCoroutine(EndLevelRoutine());
				}
			}
		}
	}
	#endregion

	#region Public Methods

	public void ContinueSpawning()
	{
		if (_currentWave < _waves.Length - 1 && _timeToNextWave > 0)
		{
			_canSpawnWaves = true;
		}
	}
	#endregion

	#region Private Methods

	IEnumerator EndLevelRoutine()
	{
		yield return new WaitForSeconds(5f);
		StartCoroutine(GameManager.Instance.EndLevelRoutine());
	}
	#endregion
}

[System.Serializable]
public class WaveObject
{
	public float _timeToSpawn;
	public EnemyWave _theWave;
}

