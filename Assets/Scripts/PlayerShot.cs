using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
	#region Fields

	[SerializeField] float _shotSpeed = 7f;
	[SerializeField] GameObject _impactEffect, _objectExplosion;

	#endregion

	#region MonoBehaviour Methods
	
	void Update() 
	{
		transform.position += new Vector3(_shotSpeed * Time.deltaTime, 0f, 0f);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Instantiate(_impactEffect, transform.position, Quaternion.identity);

		if (other.CompareTag("SpaceObject"))
		{
			Instantiate(_objectExplosion, other.transform.position, Quaternion.identity);
			Destroy(other.gameObject);
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
