using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
	public Rigidbody Rigidbody;
	public float Speed = 3f;
	public float TimeToReachSpeed;
	
	private Transform _playerTransform;

	private void Start()
	{
		
		_playerTransform = FindObjectOfType<PlayerMove>().transform;

	}

	private void FixedUpdate()
	{
		Vector3 ToPlayer = (_playerTransform.position - transform.position).normalized;
		Vector3 force = Rigidbody.mass * (ToPlayer * Speed - Rigidbody.velocity) / TimeToReachSpeed;
		Rigidbody.AddForce(force);
	}
}
