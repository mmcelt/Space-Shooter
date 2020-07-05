using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	#region Fields

	public static PlayerController Instance;

	public float _moveSpeed, _boostSpeed;
	[SerializeField] Rigidbody2D _theRB;
	[SerializeField] Transform _lowerLeftLimit, _upperRightLimit, _firePoint;
	[SerializeField] GameObject _shot, _doubleShot;
	[SerializeField] float _timeBetweenShots = 0.1f;
	[SerializeField] float _boostLength;

	public bool _doubleShotActive, _stopMovement;

	float _shotCounter, _normalSpeed, _boostCounter;

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
		_normalSpeed = _moveSpeed;
	}

	void Update() 
	{
		if (_stopMovement)
		{
			_theRB.velocity = Vector2.zero;
			return;
		}

		_theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * _moveSpeed;

		transform.position = new Vector3(Mathf.Clamp(transform.position.x, _lowerLeftLimit.position.x, _upperRightLimit.position.x), Mathf.Clamp(transform.position.y, _lowerLeftLimit.position.y, _upperRightLimit.position.y), transform.position.z);

		//firing shots...
		if (Input.GetButtonDown("Fire1"))
		{
			if (!_doubleShotActive)
				Instantiate(_shot, _firePoint.position, _firePoint.rotation);
			else
				Instantiate(_doubleShot, _firePoint.position, _firePoint.rotation);

			_shotCounter = _timeBetweenShots;
		}

		if (Input.GetButton("Fire1"))
		{
			_shotCounter -= Time.deltaTime;
			if (_shotCounter <= 0)
			{
				if(!_doubleShotActive)
					Instantiate(_shot, _firePoint.position, _firePoint.rotation);
				else
					Instantiate(_doubleShot, _firePoint.position, _firePoint.rotation);

				_shotCounter = _timeBetweenShots;
			}
		}

		if (_boostCounter > 0)
		{
			_boostCounter -= Time.deltaTime;
			if (_boostCounter <= 0)
			{
				_moveSpeed = _normalSpeed;
			}
		}
	}
	#endregion

	#region Public Methods

	public void ActivateSpeedBoost()
	{
		_boostCounter = _boostLength;
		_moveSpeed = _boostSpeed;
	}
	#endregion

	#region Private Methods


	#endregion
}
