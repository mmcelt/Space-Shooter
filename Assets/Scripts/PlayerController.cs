using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	#region Fields

	[SerializeField] float _moveSpeed;
	[SerializeField] Rigidbody2D _theRB;

	#endregion

	#region MonoBehaviour Methods

	void Start() 
	{
		
	}
	
	void Update() 
	{
		_theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * _moveSpeed;
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
