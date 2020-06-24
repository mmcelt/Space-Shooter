using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
	#region Fields

	[SerializeField] float _shotSpeed = 7f;
	[SerializeField] GameObject _impactEffect;
	[SerializeField] int _damageToInflict = 1;

	#endregion

	#region MonoBehaviour Methods

	void Start() 
	{
		
	}
	
	void Update() 
	{
		transform.position -= new Vector3(_shotSpeed * Time.deltaTime, 0f, 0f);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Instantiate(_impactEffect, transform.position, Quaternion.identity);

		if (other.CompareTag("Player"))
		{
			HealthManager.Instance.DamagePlayer(_damageToInflict);
		}

		Destroy(gameObject);
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
