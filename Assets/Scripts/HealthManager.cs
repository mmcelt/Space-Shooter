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
	[SerializeField] float _invincibleLength = 2f;
	[SerializeField] SpriteRenderer _theSprite;

	float _invincibleCounter;

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
		UIManager.Instance._livesText.text = "X " + GameManager.Instance._currentLives;
		UIManager.Instance._healthbar.maxValue = _maxHealth;
		UIManager.Instance._healthbar.value = _currentHealth;
	}

	void Update() 
	{
		if (_invincibleCounter >= 0)
		{
			_invincibleCounter -= Time.deltaTime;

			if (_invincibleCounter <= 0)
			{
				_theSprite.color = new Color(_theSprite.color.r, _theSprite.color.g, _theSprite.color.b, 1.0f);
			}
		}
	}
	#endregion

	#region Public Methods

	public void DamagePlayer(int amount = 1)
	{
		if (_invincibleCounter > 0) return;

		_currentHealth -= amount;
		_currentHealth = Mathf.Max(0, _currentHealth);

		UIManager.Instance._healthbar.value = _currentHealth;

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

		UIManager.Instance._healthbar.value = _currentHealth;

		_invincibleCounter = _invincibleLength;
		_theSprite.color = new Color(_theSprite.color.r, _theSprite.color.g, _theSprite.color.b, 0.5f);
	}
	#endregion

	#region Private Methods


	#endregion
}
