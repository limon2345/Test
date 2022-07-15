using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
	
	public int  Health;
	public UnityEvent EventToTakeDamage;
	

	public void TakeDamage(int damagevalue){
		Health -= damagevalue;
		if(Health <= 0)
		{
			Die();
		}
		EventToTakeDamage.Invoke();
	}

	public void Die(){
		Destroy(gameObject);
	}
	
}
