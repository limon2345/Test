using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{
   [SerializeField] Vector3 RotateSpeed;
   [SerializeField] bool RotateSpeedEnabled;
    void Update()
    {
        if (RotateSpeedEnabled){
            transform.Rotate(RotateSpeed * Time.deltaTime);
        }
    }
}
