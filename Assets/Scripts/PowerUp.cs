using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
	#region Fields

	[SerializeField] bool _isShield, _isBoost, _isDoubleShot;

	#endregion

	#region MonoBehaviour Methods

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			if (_isShield)
			{
				HealthManager.Instance.ActivateShield();
			}
			if (_isBoost)
			{
				PlayerController.Instance.ActivateSpeedBoost();
			}
			if (_isDoubleShot)
			{
				PlayerController.Instance._doubleShotActive = true;
			}

			Destroy(gameObject);
		}
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
