using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnCollision : MonoBehaviour
{
	[SerializeField] private int _damagevalue = 1;
	private void OnCollisionEnter(Collision collision)
	{
	    if(collision.rigidbody){
			var player = collision.rigidbody.GetComponent<PlayerHealth>();
			if(player)
			{
				player.TakeDamage(_damagevalue);
			}
		}
	}
}
