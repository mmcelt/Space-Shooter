﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
	#region Fields

	public static HealthManager Instance;

	[SerializeField] int _currentHealth, _maxHealth, _shieldPower, _shieldMaxPower = 2;
	[SerializeField] GameObject _deathEffect, _theShield;
	[SerializeField] float _invincibleLength = 2f;
	[SerializeField] SpriteRenderer _theSprite;

	float _invincibleCounter;

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
		_currentHealth = _maxHealth;
		UIManager.Instance._livesText.text = "X " + GameManager.Instance._currentLives;
		UIManager.Instance._healthbar.maxValue = _maxHealth;
		UIManager.Instance._healthbar.value = _currentHealth;
		UIManager.Instance._shieldbar.maxValue = _shieldMaxPower;
		UIManager.Instance._shieldbar.value = _shieldPower;
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
		if (_invincibleCounter <= 0)
		{
			if (_theShield.activeInHierarchy)
			{
				_shieldPower--;
				_shieldPower = Mathf.Max(0, _shieldPower);

				UIManager.Instance._shieldbar.value = _shieldPower;

				if (_shieldPower == 0)
					_theShield.SetActive(false);
			}
			else
			{
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

				PlayerController.Instance._doubleShotActive = false;
			}
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

	public void ActivateShield()
	{
		_theShield.SetActive(true);
		_shieldPower = _shieldMaxPower;
		UIManager.Instance._shieldbar.value = _shieldPower;
	}
	#endregion

	#region Private Methods


	#endregion
}
