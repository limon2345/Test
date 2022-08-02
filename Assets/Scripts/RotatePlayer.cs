using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RotatePlayer : MonoBehaviour
{
    [SerializeField] Transform Aim;
    [SerializeField] float SpeedRotate;
    void Update()
    {
        float xAimDistance = Aim.position.x - transform.position.x;
        float interpolant = Mathf.InverseLerp(-15f, 15f, xAimDistance);
        float angle = Mathf.Lerp(90f, -90f, interpolant);

        transform.localRotation = Quaternion.Euler(0, angle, 0);

        
    }


}
