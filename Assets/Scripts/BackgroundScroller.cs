using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
	#region Fields

	[SerializeField] Transform _bg1, _bg2;
	[SerializeField] float _scrollSpeed;

	float _bgWidth;

	#endregion

	#region MonoBehaviour Methods

	void Start() 
	{
		_bgWidth = _bg1.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
	}
	
	void Update() 
	{
		_bg1.position = new Vector3(_bg1.position.x - (_scrollSpeed * Time.deltaTime), _bg1.position.y, _bg1.position.z);
		_bg2.position -= new Vector3(_scrollSpeed * Time.deltaTime, 0f, 0f);

		if (_bg1.position.x < -_bgWidth - 1)
		{
			_bg1.position += new Vector3(_bgWidth * 2f, 0f, 0f);
		}

		if (_bg2.position.x < -_bgWidth - 1)
		{
			_bg2.position += new Vector3(_bgWidth * 2f, 0f, 0f);
		}

	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
