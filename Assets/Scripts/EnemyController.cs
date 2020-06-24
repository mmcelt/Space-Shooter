using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	#region Fields

	[SerializeField] float _moveSpeed;
	[SerializeField] Vector2 _startDirection;

	#endregion

	#region MonoBehaviour Methods

	void Start() 
	{
		
	}

	void Update()
	{
		//transform.position -= new Vector3(_moveSpeed * Time.deltaTime, 0f, 0f);
		transform.position += new Vector3(_startDirection.x, _startDirection.y) * _moveSpeed * Time.deltaTime;
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
