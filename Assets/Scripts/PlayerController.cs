using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	#region Fields

	[SerializeField] float _moveSpeed;
	[SerializeField] Rigidbody2D _theRB;
	[SerializeField] Transform _lowerLeftLimit, _upperRightLimit, _firePoint;
	[SerializeField] GameObject _shot;
	[SerializeField] float _timeBetweenShots = 0.1f;

	float _shotCounter;

	#endregion

	#region MonoBehaviour Methods

	void Start() 
	{
		
	}
	
	void Update() 
	{
		_theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * _moveSpeed;

		transform.position = new Vector3(Mathf.Clamp(transform.position.x, _lowerLeftLimit.position.x, _upperRightLimit.position.x), Mathf.Clamp(transform.position.y, _lowerLeftLimit.position.y, _upperRightLimit.position.y), transform.position.z);

		//firing shots...
		if (Input.GetButtonDown("Fire1"))
		{
			Instantiate(_shot, _firePoint.position, _firePoint.rotation);
			_shotCounter = _timeBetweenShots;
		}

		if (Input.GetButton("Fire1"))
		{
			_shotCounter -= Time.deltaTime;
			if (_shotCounter <= 0)
			{
				Instantiate(_shot, _firePoint.position, _firePoint.rotation);
				_shotCounter = _timeBetweenShots;
			}
		}
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
