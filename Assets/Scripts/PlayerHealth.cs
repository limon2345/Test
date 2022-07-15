using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 5;
    public int MaxHealth = 8;
 
    public AudioSource AddHealthSound;
    public UnityEvent EventToTakeDamage;
    public UnityEvent EventToAddHealth;
    
    private bool _invulnerable = false;

    public void TakeDamage(int damageValue){
        if(_invulnerable == false){
            Health -= damageValue;
            if (Health <= 0)
            {
                Health = 0;
                Die();
            }
            _invulnerable = true;
            Invoke("StopInvulnerable", 1f);

            EventToTakeDamage.Invoke();
            
        }     
	}
    void StopInvulnerable(){
        _invulnerable = false;
	}



    public void AddHealth(int healthValue){
        Health += healthValue;

        if(Health > MaxHealth){
            Health = MaxHealth;
		}
        AddHealthSound.Play();
        EventToAddHealth.Invoke();
	}
    public void Die(){
        Debug.Log("You Lose");
	}
}
