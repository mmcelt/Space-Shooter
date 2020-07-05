using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{	
	#region Fields

	
	#endregion

	#region MonoBehaviour Methods

	void Start() 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			StartCoroutine(GameManager.Instance.EndLevelRoutine());
		}
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
