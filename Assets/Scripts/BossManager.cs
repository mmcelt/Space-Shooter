using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
	#region Fields

	public static BossManager Instance;

	[SerializeField] int _currentHealth = 100;
	[SerializeField] string _bossName;

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


	#endregion
}
