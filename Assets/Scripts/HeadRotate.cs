using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadRotate : MonoBehaviour
{
    public Transform target;
    
    
    void Update()
    {
        
        float xAimDistance = target.position.x - transform.position.x;
        float interpolant = Mathf.InverseLerp(-15f, 15f, xAimDistance);
        float angle = Mathf.Lerp(90f, -90f, interpolant);

        transform.localRotation = Quaternion.Euler(0, angle, 0);
    }
}
