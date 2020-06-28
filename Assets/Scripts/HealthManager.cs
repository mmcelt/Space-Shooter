using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
	#region Fields

	public static HealthManager Instance;

	[SerializeField] int _currentHealth, _maxHealth;
	[SerializeField] GameObject _deathEffect;

	#endregion

	#region MonoBehaviour Methods

	void Awake()
	{
		if (Instance == null)
			Instance = this;
		else if(Instance != this)
			Destroy(gameObject);
	}

	void Start() 
	{
		_currentHealth = _maxHealth;
	}
	
	void Update() 
	{
		
	}
	#endregion

	#region Public Methods

	public void DamagePlayer(int amount = 1)
	{
		_currentHealth -= amount;
		_currentHealth = Mathf.Max(0, _currentHealth);

		if (_currentHealth == 0)
		{
			Instantiate(_deathEffect, transform.position, Quaternion.identity);
			gameObject.SetActive(false);

			GameManager.Instance.KillPlayer();
			WaveManager.Instance._canSpawnWaves = false;
		}
	}

	public void RespawnPlayer()
	{
		gameObject.SetActive(true);
		_currentHealth = _maxHealth;
	}
	#endregion

	#region Private Methods


	#endregion
}
