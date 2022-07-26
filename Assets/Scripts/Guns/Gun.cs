using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] float BulletSpeed = 30f;
    [SerializeField] float ShotPeriod = 0.2f;
    [SerializeField] Transform SpawnBullet;
    //public GunLoot GunLoot;
    [SerializeField] AudioSource ShotSound;
    //[SerializeField] GameObject Flash;

    private float _timer;

    void Update()
    {
        _timer += Time.deltaTime;

        if(_timer > ShotPeriod)
        {
            //if(GunLoot == false){
                if (Input.GetMouseButton(0))
                {
                    _timer = 0f;
                    Shot();
                }
            //}
           
		}
    }
    private void Shot(){
        
        GameObject newBullet = Instantiate(BulletPrefab, SpawnBullet.position, SpawnBullet.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = SpawnBullet.forward * BulletSpeed;
        
        newBullet.transform.SetParent(SpawnBullet.transform, true);
     
        ShotSound.Play();
	}
}
