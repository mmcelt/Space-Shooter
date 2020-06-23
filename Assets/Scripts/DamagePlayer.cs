using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
	#region Fields

	[SerializeField] int _damageToInflict = 1;

	#endregion

	#region MonoBehaviour Methods

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			HealthManager.Instance.DamagePlayer(_damageToInflict);
		}
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
