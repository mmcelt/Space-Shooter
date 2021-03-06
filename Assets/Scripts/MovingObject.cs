﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
	#region Fields

	[SerializeField] float _moveSpeed;

	#endregion

	#region MonoBehaviour Methods
	
	void Update() 
	{
		transform.position -= new Vector3(_moveSpeed * Time.deltaTime, 0f, 0f);
	}

	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
