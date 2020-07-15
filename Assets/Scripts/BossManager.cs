using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
	#region Fields

	public static BossManager Instance;

	public int _currentHealth = 100;

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
		
	}
	
	void Update() 
	{
		
	}


	#endregion

	#region Public Methods

	public void HurtBoss(int damageAmount)
	{
		_currentHealth -= damageAmount;
		_currentHealth = Mathf.Max(0, _currentHealth);

		if (_currentHealth == 0)
		{
			Destroy(gameObject);
		}
	}
	#endregion

	#region Private Methods


	#endregion
}
