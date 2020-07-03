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
	[Header("Shooting")]
	[SerializeField] bool _canShoot;
	[SerializeField] GameObject _bullet;
	[SerializeField] Transform _firePoint;
	[SerializeField] float _timeBetweenShots;
	[Header("Health")]
	public int _currentHealth, _scoreValue = 100;
	public GameObject _deathFX;

	float _shotCounter;
	bool _allowShooting;

	#endregion

	#region MonoBehaviour Methods

	void Start() 
	{
		_shotCounter = _timeBetweenShots;
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
		//shooting...
		if (_allowShooting && transform.position.x >= -8f)
		{
			_shotCounter -= Time.deltaTime;
			if (_shotCounter <= 0)
			{
				_shotCounter = _timeBetweenShots;
				Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
			}
		}
	}

	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}

	void OnBecameVisible()
	{
		if(_canShoot)
			_allowShooting = true;
	}
	#endregion

	#region Public Methods

	public void DamageEnemy(int damageAmount = 1)
	{
		_currentHealth -= damageAmount;
		_currentHealth = Mathf.Max(0, _currentHealth);

		if (_currentHealth == 0)
		{
			GameManager.Instance.UpdateScore(_scoreValue);
			Instantiate(_deathFX, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
	#endregion

	#region Private Methods


	#endregion
}
