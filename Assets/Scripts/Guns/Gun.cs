using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float BulletSpeed = 10f;
    public float ShotPeriod = 0.2f;
    public Transform Spawn;

    public AudioSource ShotSound;
    public GameObject Flash;

    private float _timer;
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > ShotPeriod)
        {
            if (Input.GetMouseButton(0))
            {
                _timer = 0f;
                Shot();
            }
        }
    }
    public virtual void Shot() {
        GameObject newBullet = Instantiate(BulletPrefab, Spawn.position, Spawn.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = Spawn.forward * BulletSpeed;
        ShotSound.Play();
        Flash.SetActive(true);
        Invoke("HideFlash", 0.08f);
    }

    private void HideFlash(){
        Flash.SetActive(false);
	}

    public virtual void Activate(){
        gameObject.SetActive(true);
	}
    public virtual void Deactivate(){
        gameObject.SetActive(false);
	}
    
    public virtual void AddBullets(int numerOfBullets){
        
	}
}

