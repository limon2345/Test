using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed = 30f;
    [SerializeField] private float _shotPeriod = 0.2f;
    [SerializeField] private Transform _spawnBullet;
   
    [SerializeField] private AudioSource ShotSound;
    [SerializeField] private GameObject Flash;

    private float _timer;


	public void Update()
    {
        _timer += Time.deltaTime;

        if(_timer > _shotPeriod)
        {          
            if (Input.GetMouseButton(0))
                {
                    _timer = 0f;
                    Shot();
                }
            
           
		}
    }
    public void Shot(){
        
        GameObject newBullet = Instantiate(_bulletPrefab, _spawnBullet.position, _spawnBullet.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = _spawnBullet.forward * _bulletSpeed;
        Destroy(newBullet, 2f);
        ShotSound.Play();
        Flash.SetActive(true);
        Invoke("HideFlash", 0.08f);      
	}

    public void HideFlash(){
        Flash.SetActive(false);
	}

}
