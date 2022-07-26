using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerArmory : MonoBehaviour
{
    [SerializeField] GameObject Prefab;
    [SerializeField] Transform[] Spawns;
    [SerializeField] AudioSource CreateSound;
   
   
    
    public void Create()
    {
        for (int i = 0; i < Spawns.Length; i++)
        {
            GameObject newGun = Instantiate(Prefab, Spawns[i].position, Spawns[i].rotation);
            newGun.transform.parent = transform;           
        }    
        CreateSound.Play();
    }

    
    
}
