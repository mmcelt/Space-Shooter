﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
	#region Fields

	public static BossManager Instance;

	[SerializeField] int _currentHealth = 100;
	[SerializeField] string _bossName;
	[SerializeField] BattleShot[] _shotsToFire;

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
		UIManager.Instance._bossHealthbar.maxValue = _currentHealth;
		UIManager.Instance._bossHealthbar.value = _currentHealth;
		UIManager.Instance._bossNameText.text = _bossName;
		UIManager.Instance._bossHealthbar.gameObject.SetActive(true);
		MusicController.Instance.PlayBossMusic();
	}

	void Update()
	{
		for(int i=0; i<_shotsToFire.Length; i++)
		{
			_shotsToFire[i]._shotCounter -= Time.deltaTime;

			if (_shotsToFire[i]._shotCounter <= 0)
			{
				_shotsToFire[i]._shotCounter = _shotsToFire[i]._timeBetweenShots;
				Instantiate(_shotsToFire[i]._theShot, _shotsToFire[i]._firePoint.position, _shotsToFire[i]._firePoint.rotation);
			}
		}
	}
	#endregion

	#region Public Methods

	public void HurtBoss(int damageAmount)
	{
		_currentHealth -= damageAmount;
		_currentHealth = Mathf.Max(0, _currentHealth);
		UIManager.Instance._bossHealthbar.value = _currentHealth;

		if (_currentHealth == 0)
		{
			Destroy(gameObject);
			UIManager.Instance._bossHealthbar.gameObject.SetActive(false);
		}
	}
	#endregion

	#region Private Methods

	void FireShot()
	{

	}
	#endregion
}

[System.Serializable]
public class BattleShot
{
	public GameObject _theShot;
	public float _timeBetweenShots, _shotCounter;
	public Transform _firePoint;
}
