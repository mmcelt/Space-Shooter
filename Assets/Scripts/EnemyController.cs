using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	#region Fields

	[SerializeField] float _moveSpeed;
	[SerializeField] Vector2 _startDirection;
	[Header("Change Direction")]
	[SerializeField] bool _shouldChangeDirection;
	[SerializeField] float _changeDirectionXPoint;
	[SerializeField] Vector2 _changedDirection;

	#endregion

	#region MonoBehaviour Methods

	void Start() 
	{
		
	}

	void Update()
	{
		//transform.position -= new Vector3(_moveSpeed * Time.deltaTime, 0f, 0f);
		if (!_shouldChangeDirection)
		{
			transform.position += new Vector3(_startDirection.x, _startDirection.y) * _moveSpeed * Time.deltaTime;
		}
		else
		{
			if (transform.position.x > _changeDirectionXPoint)
			{
				transform.position += new Vector3(_startDirection.x, _startDirection.y) * _moveSpeed * Time.deltaTime;
			}
			else
			{
				transform.position += new Vector3(_changedDirection.x, _changedDirection.y) * _moveSpeed * Time.deltaTime;
			}
		}
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
