using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHen : MonoBehaviour
{
    public GameObject HenPrefab;
    public Transform[] Spawns;
    

    public void Create_Hen(){

        for(int i = 0; i < Spawns.Length; i++){
            Instantiate(HenPrefab, Spawns[i].position, Spawns[i].rotation);
		}
	}
}
